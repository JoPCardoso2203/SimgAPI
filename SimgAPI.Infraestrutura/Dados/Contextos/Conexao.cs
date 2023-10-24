using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace SimgAPI.Infraestrutura.Dados.Contextos
{
    public static class Conexao
    {
        public static SqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao.GetConnectionString("StringConexao"); 
            SqlConnection conexao = new SqlConnection(connectionString);
            return conexao;
        }
    }
}
