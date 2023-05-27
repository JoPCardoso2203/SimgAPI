using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDispositivo
    {
        List<Dispositivo> ListarDispositivos();
        Dispositivo? ObterDispositivoPorId(decimal id);
        List<Dispositivo>? ObterDispositivoPorIdUsuario(decimal id);
    }
}
