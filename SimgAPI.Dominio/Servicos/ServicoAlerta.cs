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

namespace SimgAPI.Dominio.Servicos
{
    public class ServicoAlerta : IServicoAlerta
    {
        private readonly IRepositorioAlerta _repositorioAlerta;
        public ServicoAlerta(IRepositorioAlerta repositorioAlerta)
        {
            _repositorioAlerta = repositorioAlerta;
        }

        public void CadastrarAlertaPorJson(string json)
        {
            var objeto = JsonConvert.DeserializeObject<JsonLeituraDto>(json);
            Alerta alerta = new()
            {
                IdAlerta = 1,
                IdDispositivo = Convert.ToDecimal(objeto?.Id ?? "0"),
                DataAlerta = DateTime.Now
            };

            _repositorioAlerta.AdicionarAlerta(alerta);
        }
    }
}
