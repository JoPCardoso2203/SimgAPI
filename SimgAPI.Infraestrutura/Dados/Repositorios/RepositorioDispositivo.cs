
using Microsoft.Extensions.Configuration;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Infraestrutura.Dados.Repositorios
{
    public class RepositorioDispositivo : RepositorioBase, IRepositorioDispositivo
    {
        public RepositorioDispositivo(IConfiguration configuracao) : base(configuracao)
        {
        }

        public List<Dispositivo> ListarDispositivos()
        {
            var consulta = $@"SELECT 
                                DISP_ID IdDispositivo,
                                DISP_USUA_ID IdUsuario,
                                DISP_DTHR_CRIACAO DataCriacaoDispositivo
                              FROM DISPOSITIVO";

            var lista = ObterLista<Dispositivo>(consulta);
            return lista;
        }

        public Dispositivo? ObterDispositivoPorId(decimal id)
        {
            var consulta = $@"SELECT 
                                DISP_ID IdDispositivo,
                                DISP_USUA_ID IdUsuario,
                                DISP_DTHR_CRIACAO DataCriacaoDispositivo
                              FROM DISPOSITIVO WHERE DISP_ID = @pIdDispositivo";

            var dispositivo = Obter<Dispositivo>(consulta, new { pIdDispositivo = id });
            return dispositivo;
        }

        public List<Dispositivo>? ObterDispositivoPorIdUsuario(decimal id)
        {
            var consulta = $@"SELECT 
                                DISP_ID IdDispositivo,
                                DISP_USUA_ID IdUsuario,
                                DISP_DTHR_CRIACAO DataCriacaoDispositivo
                              FROM DISPOSITIVO WHERE DISP_USUA_ID = @pIdUsuario";

            var dispositivo = ObterLista<Dispositivo>(consulta, new { pIdUsuario = id });
            return dispositivo;
        }
    }
}
