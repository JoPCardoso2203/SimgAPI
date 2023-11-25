using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace SimgAPI.Infraestrutura.Dados.Contextos
{
    public static class Conexao
    {
        public static MySqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao.GetConnectionString("StringConexao");
            MySqlConnection conexao = new MySqlConnection(connectionString);
            return conexao;
        }
    }
}
