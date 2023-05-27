using Dapper;
using Microsoft.Extensions.Configuration;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;
using SimgAPI.Infraestrutura.Dados.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBase : IRepositorioBase
    {
        IConfiguration _configuracao;

        public RepositorioBase(IConfiguration configuration)
        {
            _configuracao = configuration;
        }

        public bool Adicionar<T>(T objeto)
        {
            if (objeto != null)
            {
                using var db = new ContextEntity(_configuracao);
                var retorno = db.Add(objeto);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public bool Atualizar<T>(T objeto)
        {
            if (objeto != null)
            {
                using var db = new ContextEntity(_configuracao);
                var retorno = db.Update(objeto);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public bool Remover<T>(T objeto)
        {
            if (objeto != null)
            {
                using var db = new ContextEntity(_configuracao);
                var retorno = db.Remove(objeto);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public T? Obter<T>(string consulta, object? parametros = null)
        {
            using var db = Conexao.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).FirstOrDefault();
            return retorno;
        }

        public List<T> ObterLista<T>(string consulta, object? parametros = null)
        {
            using var db = Conexao.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).ToList();
            return retorno;
        }
    }
}
