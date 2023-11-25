using SimgAPI.Dominio.Auxiliares;
using SimgAPI.Dominio.Entidades;
using SimgAPI.Dominio.Interfaces.Repositorios;
using SimgAPI.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioDispositivo _repositorioDispositivo;
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioDispositivo repositorioDispositivo)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioDispositivo = repositorioDispositivo;
        }

        public object? ValidarUsuario(string login, string senha)
        {
            var usuario = _repositorioUsuario.ObterUsuarioPorLoginSenha(login, senha);

            if (usuario != null)
            {
                return new { Login = usuario.LoginUsuario, Nome = usuario.NomeUsuario };
            }
            else
            {
                return null;
            }
        }

        public object? ListarDispositivos(string Login)
        {
            var usuario = _repositorioUsuario.ObterUsuarioPorLogin(Login);
            var dispositivos = _repositorioDispositivo.ObterDispositivoPorIdUsuario(usuario?.IdUsuario ?? 0);

            if(dispositivos != null && dispositivos.Count > 0)
                return dispositivos?.Select(p => new { p.IdDispositivo, DataCriacao = p.DataCriacaoDispositivo }).ToList();

            return null;
        }

        public object? RegistrarUsuario(UsuarioDTO usuario)
        {
            var novoUsuario = new Usuario()
            {
                LoginUsuario = usuario.Cpf,
                SenhaUsuario = usuario.Senha,
                NomeUsuario = usuario.Nome,
                TelefoneUsuario = usuario.Telefone,
                DataCriacaoUsuario = DateTime.Now
            };
            _repositorioUsuario.RegistrarUsuario(novoUsuario);

            return null;
        }
    }
}
