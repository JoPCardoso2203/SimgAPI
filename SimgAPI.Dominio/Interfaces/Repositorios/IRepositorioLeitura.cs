using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioLeitura
    {
        List<Leitura> ListarLeituras();
        Leitura? ObterLeituraPorId(decimal id);
        bool AdicionarLeitura(Leitura leitura);
        List<Leitura> ListarLeiturasPorDispositivo(decimal idDispositivo, DateTime? dataDe = null, DateTime? dataAte = null);
    }
}
