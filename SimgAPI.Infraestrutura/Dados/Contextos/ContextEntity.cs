using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Infraestrutura.Dados.Contextos
{
    public class ContextEntity : DbContext
    {
        IConfiguration _configuracao;
        public ContextEntity(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Conexao.ObterConexao(_configuracao));
        }

        public DbSet<Alerta> Alerta { get; set; }
        public DbSet<Leitura> Leitura { get; set; }
    }
}
