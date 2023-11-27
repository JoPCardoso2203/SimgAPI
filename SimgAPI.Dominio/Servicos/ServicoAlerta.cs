using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SimgAPI.Dominio.Auxiliares;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;
using SimgAPI.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalVoice;
using TotalVoice.Api;

namespace SimgAPI.Dominio.Servicos
{
    public class ServicoAlerta : IServicoAlerta
    {
        private readonly IRepositorioAlerta _repositorioAlerta;
        private readonly IServicoDispositivo _servicoDispositivo;
        private readonly IConfiguration _configuracao;
        public ServicoAlerta(IRepositorioAlerta repositorioAlerta, IServicoDispositivo servicoDispositivo, IConfiguration configuracao)
        {
            _repositorioAlerta = repositorioAlerta;
            _servicoDispositivo = servicoDispositivo;
            _configuracao = configuracao;
        }

        public void CadastrarAlertaPorJson(string json)
        {
            var objeto = JsonConvert.DeserializeObject<JsonLeituraDto>(json);
            Alerta alerta = new()
            {
                IdDispositivo = Convert.ToDecimal(objeto?.Id),
                DataAlerta = DateTime.Now
            };

            _repositorioAlerta.AdicionarAlerta(alerta);
        }

        public void FazerLigacao(string jsonLeitura)
        {
            var objeto = JsonConvert.DeserializeObject<JsonLeituraDto>(jsonLeitura);

            var alerta = _repositorioAlerta.ListarAlertasPorDispositivo(objeto?.Id).OrderByDescending(p => p.DataAlerta).FirstOrDefault();

            if (alerta == null || (alerta.DataAlerta != null && DateTime.Now.Subtract(alerta.DataAlerta ?? new DateTime()).TotalMinutes > 2))
            {
                var usuario = _servicoDispositivo.ObterLoginUsuarioPorDispositivoId(1);
                TotalVoiceClient client = new TotalVoiceClient(_configuracao["TokenTTS"]);
                Tts tts = new Tts(client);
                var json = new
                {
                    numero_destino = usuario?.TelefoneUsuario,
                    mensagem = "Sensor de chama acionado Por favor entre em contato com os bombeiros! Sensor de chama acionado Por favor entre em contato com os bombeiros! Sensor de chama acionado Por favor entre em contato com os bombeiros! Sensor de chama acionado Por favor entre em contato com os bombeiros!"
                };
                string response = tts.Enviar(json);

                CadastrarAlertaPorJson(jsonLeitura);
            }
        }
    }
}
