using Microsoft.AspNetCore.Mvc;
using SimgAPI.Dominio.Interfaces.Servicos;

namespace SimgAPI.Controllers
{
    [Route("[controller]")]
    public class LeituraController : Controller
    {
        private readonly IServicoLeitura _servicoLeitura;
        public LeituraController(IServicoLeitura servicoLeitura)
        {
            _servicoLeitura = servicoLeitura;
        }

        [HttpGet("ObterLista")]
        public IActionResult ObterLista()
        {
            var obj = Json(new { Valor1 = "Teste" });
            return Ok(obj);

        }

        [HttpGet("ListarLeituras")]
        public IActionResult ListarLeituras(decimal idDispositivo, DateTime? dataDe, DateTime? dataAte)
        {
            var lista = _servicoLeitura.ListarLeiturasPorDispositivo(idDispositivo, dataDe, dataAte);
            if (lista == null)
            {
                return BadRequest("Nenhuma leitura foi encontrada!");
            }
            return Ok(lista);

        }
    }
}
