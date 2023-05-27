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
    public class ServicoDispositivo : IServicoDispositivo
    {
        private IRepositorioDispositivo _repositorioDispositivo;
        private IRepositorioUsuario _RepositorioUsuario;
        public ServicoDispositivo(IRepositorioDispositivo repositorioDispositivo, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioDispositivo = repositorioDispositivo;
            _RepositorioUsuario = repositorioUsuario;
        }

        public string? ObterLoginUsuarioPorDispositivoId(decimal idDispositivo)
        {
            var dispositivo = _repositorioDispositivo.ObterDispositivoPorId(idDispositivo);
            
            if(dispositivo != null)
            {
                var usuario = _RepositorioUsuario.ObterUsuarioPorId(dispositivo.IdUsuario ?? 0);
                return usuario?.LoginUsuario;
            }

            return null;
        }
    }
}
