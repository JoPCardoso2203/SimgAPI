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
    public class ServicoLeitura : IServicoLeitura
    {
        private readonly IRepositorioLeitura _repositorioLeitura;
        public ServicoLeitura(IRepositorioLeitura repositorioLeitura)
        {
            _repositorioLeitura = repositorioLeitura;
        }

        public List<Leitura> ObterLeituras()
        {
            return _repositorioLeitura.ListarLeituras();
        }

        public void CadastrarLeituraPorJson(string json)
        {
            var objeto = JsonConvert.DeserializeObject<JsonLeituraDto>(json);
            Leitura leitura = new() 
            { 
                IdLeitura = 1,
                DataLeitura = DateTime.Now,
                JsonLeitura = json,
                IdDispositivo = 1,
                ValorChama = objeto?.Chama,
                ValorGas = objeto?.Gas,
            };
            
            _repositorioLeitura.AdicionarLeitura(leitura);
        }

        public object? ListarLeiturasPorDispositivo(decimal idDispositivo, DateTime? dataDe = null, DateTime? dataAte = null)
        {
            var lista = _repositorioLeitura.ListarLeiturasPorDispositivo(idDispositivo, dataDe, dataAte).Select(p => new { p.IdDispositivo, p.ValorGas, p.DataLeitura}).ToList();
            if(lista == null || lista.Count < 1) return null;
            return lista;
        }
    }
}
