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
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public RepositorioUsuario(IConfiguration configuracao) : base(configuracao) 
        { 
        }

        public List<Usuario> ListarUsuarios()
        {
            var consulta = $@"SELECT 
                                USUA_ID IdUsuario,
                                USUA_NOME NomeUsuario,
                                USUA_LOGIN LoginUsuario,
                                USUA_SENHA SenhaUsuario,
                                USUA_TELEFONE TelefoneUsuario,
                                USUA_DTHR_CRIACAO DataCriacaoUsuario
                              FROM SIMG.USUARIO";

            var lista = ObterLista<Usuario>(consulta);
            return lista;
        }

        public Usuario? ObterUsuarioPorId(decimal id)
        {
            var consulta = $@"SELECT 
                                USUA_ID IdUsuario,
                                USUA_NOME NomeUsuario,
                                USUA_LOGIN LoginUsuario,
                                USUA_SENHA SenhaUsuario,
                                USUA_TELEFONE TelefoneUsuario,
                                USUA_DTHR_CRIACAO DataCriacaoUsuario
                              FROM SIMG.USUARIO WHERE USUA_ID = @pIdUsuario";

            var usuario = Obter<Usuario>(consulta, new { pIdUsuario = id });
            return usuario;
        }

        public Usuario? ObterUsuarioPorLogin(string login)
        {
            var consulta = $@"SELECT 
                                USUA_ID IdUsuario,
                                USUA_NOME NomeUsuario,
                                USUA_LOGIN LoginUsuario,
                                USUA_SENHA SenhaUsuario,
                                USUA_TELEFONE TelefoneUsuario,
                                USUA_DTHR_CRIACAO DataCriacaoUsuario
                              FROM SIMG.USUARIO WHERE USUA_LOGIN = @pLoginUsuario";

            var usuario = Obter<Usuario>(consulta, new { pLoginUsuario = login });
            return usuario;
        }

        public Usuario? ObterUsuarioPorLoginSenha(string login, string senha)
        {
            var consulta = $@"SELECT 
                                USUA_ID IdUsuario,
                                USUA_NOME NomeUsuario,
                                USUA_LOGIN LoginUsuario,
                                USUA_SENHA SenhaUsuario,
                                USUA_TELEFONE TelefoneUsuario,
                                USUA_DTHR_CRIACAO DataCriacaoUsuario
                              FROM SIMG.USUARIO WHERE USUA_LOGIN = @pLoginUsuario AND USUA_SENHA = @pSenhaUsuario";

            var usuario = Obter<Usuario>(consulta, new { pLoginUsuario = login, pSenhaUsuario = senha });
            return usuario;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            return Adicionar<Usuario>(usuario);
        }
    }
}
