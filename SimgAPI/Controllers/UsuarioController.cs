﻿using Microsoft.AspNetCore.Mvc;
using SimgAPI.Dominio.Auxiliares;
using SimgAPI.Dominio.Interfaces.Servicos;

namespace SimgAPI.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IServicoUsuario _servicoUsuario;
        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpPost("Validar")]
        public IActionResult Validar(string login, string senha)
        {
            var obj = _servicoUsuario.ValidarUsuario(login, senha);

            if (obj == null)
            {
                return BadRequest("Usuário e/ou Senha Inválidos!");
            }

            return Ok(obj);

        }

        [HttpGet("ListarDispositivos")]
        public IActionResult ListarDispositivos(string login)
        {
            var obj = _servicoUsuario.ListarDispositivos(login);

            if (obj == null)
            {
                return BadRequest("Nenhum dispositivo encontrado!");
            }

            return Ok(obj);

        }

        [HttpPost("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(UsuarioDTO usuario)
        {
            var obj = _servicoUsuario.RegistrarUsuario(usuario);

            return Ok();
        }

        [HttpPatch("AtualizarSenha")]
        public IActionResult AtualizarSenha(UsuarioDTO usuario)
        {
            var obj = _servicoUsuario.AtualizarSenha(usuario);

            return Ok();
        }
    }
}
