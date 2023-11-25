using SimgAPI.Dominio.Auxiliares;
using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Servicos
{
    public interface IServicoUsuario
    {
        object? ValidarUsuario(string login, string senha);
        object? ListarDispositivos(string Login);
        object? RegistrarUsuario(UsuarioDTO usuario);
    }
}
