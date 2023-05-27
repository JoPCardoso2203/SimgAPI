using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Infraestrutura.Dados.Contextos
{
    public static class Conexao
    {
        public static OracleConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao["StringConexao"];
            OracleConnection conexao = new OracleConnection(connectionString);
            return conexao;
        }
    }
}
