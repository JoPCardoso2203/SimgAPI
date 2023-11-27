using Microsoft.Extensions.Configuration;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;

namespace SimgAPI.Infraestrutura.Dados.Repositorios
{
    public class RepositorioLeitura : RepositorioBase, IRepositorioLeitura
    {
        public RepositorioLeitura(IConfiguration configuracao) : base(configuracao)
        {
        }

        public List<Leitura> ListarLeituras()
        {
            var consulta = $@"SELECT 
                                LEIT_ID IdLeitura,
                                LEIT_DISP_ID IdDispositivo,
                                LEIT_VALOR ValorLeitura,
                                LEIT_JSON JsonLeitura,
                                LEIT_DTHR_CRIACAO DataLeitura
                              FROM LEITURA";

            List<Leitura> lista = ObterLista<Leitura>(consulta);

            return lista;
        }

        public List<Leitura> ListarLeiturasPorDispositivo(decimal idDispositivo, DateTime? dataDe = null, DateTime? dataAte = null)
        {
            if(dataAte == null) 
            { 
                dataAte = DateTime.Now;
                dataDe = dataAte.Value.AddDays(-1);
            }


            var consulta = $@"SELECT
                            LEIT_ID IdLeitura,
                            LEIT_DISP_ID IdDispositivo,
                            LEIT_VALOR_GAS  ValorGas,
                            LEIT_VALOR_CHAMA  ValorChama,
                            LEIT_JSON JsonLeitura,
                            LEIT_DTHR_CRIACAO DataLeitura
                            FROM LEITURA 
                            WHERE LEIT_DISP_ID = 1 
                            AND LEIT_DTHR_CRIACAO BETWEEN STR_TO_DATE('26/11/2023 18:55:18', '%d/%m/%Y %H:%i:%s') AND STR_TO_DATE('27/11/2023 18:55:18', '%d/%m/%Y %H:%i:%s');
";

            List<Leitura> lista = ObterLista<Leitura>(consulta, new { pIdDispositivo = idDispositivo, pDataDe = dataDe?.ToString("dd/MM/yyyy HH:mm:ss"), pDataAte = dataAte?.ToString("dd/MM/yyyy HH:mm:ss") });

            return lista;
        }

        public Leitura? ObterLeituraPorId(decimal id)
        {
            var consulta = $@"SELECT 
                                LEIT_ID IdLeitura,
                                LEIT_DISP_ID IdDispositivo,
                                LEIT_VALOR ValorLeitura,
                                LEIT_JSON JsonLeitura,
                                LEIT_DTHR_CRIACAO DataLeitura 
                              FROM LEITURA WHERE LEIT_ID = @pIdLeitura";

            Leitura? leitura = Obter<Leitura>(consulta, new { pIdLeitura = id });

            return leitura;
        }

        public bool AdicionarLeitura(Leitura leitura)
        {
            return Adicionar<Leitura>(leitura);
        }
    }
}
