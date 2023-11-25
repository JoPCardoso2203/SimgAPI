using Microsoft.Extensions.Configuration;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;

namespace SimgAPI.Infraestrutura.Dados.Repositorios
{
    public class RepositorioAlerta : RepositorioBase, IRepositorioAlerta
    {
        public RepositorioAlerta(IConfiguration configuracao) : base(configuracao)
        {
        }

        public List<Alerta> ListarAlertas()
        {
            var consulta = $@"SELECT 
                                ALER_ID IdAlerta,
                                ALER_DISP_ID IdDispositivo,
                                ALER_DTHR_CRIACAO DataAlerta
                              FROM ALERTA";

            var lista = ObterLista<Alerta>(consulta);
            return lista;
        }

        public List<Alerta> ListarAlertasPorDispositivo(string idDispositivo)
        {
            var consulta = $@"SELECT 
                                ALER_ID IdAlerta,
                                ALER_DISP_ID IdDispositivo,
                                ALER_DTHR_CRIACAO DataAlerta
                              FROM ALERTA WHERE ALER_DISP_ID = @pIdDispositivo";

            var lista = ObterLista<Alerta>(consulta, new { pIdDispositivo = idDispositivo });
            return lista;
        }

        public Alerta? ObterAlertaPorId(decimal id)
        {
            var consulta = $@"SELECT 
                                ALER_ID IdAlerta,
                                ALER_DISP_ID IdDispositivo,
                                ALER_DTHR_CRIACAO DataAlerta 
                              FROM ALERTA WHERE ALER_ID = @pIdAlerta";

            var alerta = Obter<Alerta>(consulta, new { pIdAlerta = id });
            return alerta;
        }

        public bool AdicionarAlerta(Alerta alerta)
        {
            return Adicionar<Alerta>(alerta);
        }
    }
}
