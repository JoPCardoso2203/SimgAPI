using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAlerta
    {
        List<Alerta> ListarAlertas();
        Alerta? ObterAlertaPorId(decimal id);
        bool AdicionarAlerta(Alerta alerta);
    }
}
