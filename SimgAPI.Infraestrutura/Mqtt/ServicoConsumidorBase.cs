using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Newtonsoft.Json;
using Serilog;
using SimgAPI.Dominio.Auxiliares;
using SimgAPI.Dominio.Interfaces.Servicos;
using System.Text;
using System.Text.RegularExpressions;

namespace SimgAPI.Infraestrutura.Mqtt
{
    public class ServicoConsumidorBase : BackgroundService
    {
        private readonly ILogger<ServicoConsumidorBase> _logger;
        private readonly MqttClientOptionsBuilder builder;
        private readonly ManagedMqttClientOptions options;
        private readonly IManagedMqttClient _mqttClient;
        private readonly IServicoLeitura _servicoLeitura;
        private readonly IServicoDispositivo _servicoDispositivo;
        private readonly IServicoAlerta _servicoAlerta;

        public ServicoConsumidorBase(ILogger<ServicoConsumidorBase> logger, IServicoLeitura servicoLeitura, IServicoDispositivo servicoDispositivo, IServicoAlerta servicoAlerta)
        {
            _servicoLeitura = servicoLeitura;
            _servicoDispositivo = servicoDispositivo;
            _servicoAlerta = servicoAlerta;

            _logger = logger;
            // Creates a new client
            builder = new MqttClientOptionsBuilder()
                                                    .WithClientId("Dev2")
                                                    .WithTcpServer("185.187.235.161", 1883)
                                                    .WithCredentials("master", "mqtt12345");

            // Create client options objects
            options = new ManagedMqttClientOptionsBuilder()
                                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                                    .WithClientOptions(builder.Build())
                                    .Build();

            // Creates the client object
            _mqttClient = new MqttFactory().CreateManagedMqttClient();

            _mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            _mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);
            _mqttClient.ConnectingFailedHandler = new ConnectingFailedHandlerDelegate(OnConnectingFailed);

            _mqttClient.UseApplicationMessageReceivedHandler(msg =>
            {
                var payloadText = Encoding.UTF8.GetString(msg?.ApplicationMessage?.Payload ?? Array.Empty<byte>());
                var valores = ObterValoresJson(payloadText);

                var obj = JsonConvert.DeserializeObject<JsonLeituraDto>(valores);
                var login = _servicoDispositivo.ObterLoginUsuarioPorDispositivoId(Convert.ToDecimal(obj.Id))?.LoginUsuario;

                if (obj?.Chama?.Equals("C") ?? false)
                    _servicoAlerta.FazerLigacao(valores);

                _servicoLeitura.CadastrarLeituraPorJson(valores);

                Console.WriteLine(payloadText);
            });
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _mqttClient.StartAsync(options);

            await _mqttClient.SubscribeAsync(
                new MqttTopicFilter
                {
                    Topic = "v3/projetos-inovfablab@ttn/devices/simi/up"
                },
                new MqttTopicFilter
                {
                    Topic = "v3/projetos-inovfablab@ttn/devices/simi2/up"
                },
                new MqttTopicFilter
                {
                    Topic = "v3/projetos-inovfablab@ttn/devices/simi3/up"
                },
                new MqttTopicFilter
                {
                    Topic = "/Simi/Alerta"
                }
            );
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _mqttClient.StopAsync();
            await base.StopAsync(cancellationToken);
        }

        private static void OnConnected(MqttClientConnectedEventArgs obj)
        {
            Console.WriteLine(@"Successfully connected.");
        }

        private static void OnConnectingFailed(ManagedProcessFailedEventArgs obj)
        {
            Console.WriteLine("Couldn't connect to broker.");
        }

        private static void OnDisconnected(MqttClientDisconnectedEventArgs obj)
        {
            Console.WriteLine("Successfully disconnected.");
        }

        private string ObterValoresJson(string json)
        {
            var padrao = "(?:\\\"|\\')(?<key>[\\w\\d]+)(?:\\\"|\\')(?:\\:\\s*)(?:\\\"|\\')?(?<value>[\\w\\s-]*)(?:\\\"|\\')?";
            var valores = Regex.Matches(json, padrao).ToList();
            var valoresString = valores.Where(x => x.Value.Contains("Gas") || x.Value.Contains("Id") || x.Value.Contains("Chama")).Select(x => x.Value).ToList();
            return "{ " + string.Join(',', valoresString.ToArray()) + " }";
        }
    }
}
