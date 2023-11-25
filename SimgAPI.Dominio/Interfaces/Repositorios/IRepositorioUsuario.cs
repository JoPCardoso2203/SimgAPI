using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioUsuario
    {
        List<Usuario> ListarUsuarios();
        Usuario? ObterUsuarioPorId(decimal id);
        Usuario? ObterUsuarioPorLoginSenha(string login, string senha);
        Usuario? ObterUsuarioPorLogin(string login);
        bool RegistrarUsuario(Usuario usuario);
    }
}
