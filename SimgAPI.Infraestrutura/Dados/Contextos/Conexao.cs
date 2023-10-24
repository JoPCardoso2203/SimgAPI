using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Infraestrutura.Dados.Contextos
{
    public static class Conexao
    {
        public static MySqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao["StringConexao"];
            MySqlConnection conexao = new MySqlConnection(connectionString);
            return conexao;
        }
    }
}
