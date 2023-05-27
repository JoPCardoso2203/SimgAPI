using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Servicos
{
    public interface IServicoLeitura
    {
        List<Leitura> ObterLeituras();
        void CadastrarLeituraPorJson(string json);
        object? ListarLeiturasPorDispositivo(decimal idDispositivo, DateTime? dataDe = null, DateTime? dataAte = null);
    }
}
