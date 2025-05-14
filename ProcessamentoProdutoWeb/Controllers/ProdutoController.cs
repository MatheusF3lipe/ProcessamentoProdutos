using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcessamentoProdutosAplication.Interface;
using ProcessamentoProdutosDomain.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessamentoProdutoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProcessamentoService processamentoService) : ControllerBase
    {
        private readonly IProcessamentoService _processamentoService = processamentoService;
        [HttpGet("Pedido")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(2000);
            return Ok(_processamentoService.VerificarProcessamento().Select(x => x += " - Processado").ToList());

        }
        [HttpGet("Pedido/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(2000);
            var pedido = _processamentoService.VerificarProcessamento().FirstOrDefault(x => x.Contains(id));
            return String.IsNullOrEmpty(pedido) ? NotFound($"Pedido com id {id} não encontrado.") : Ok(pedido += " - Processado");
        }

        // POST api/<ProdutoController>
        [HttpPost("pedidos")]
        public async Task<IActionResult> Post([FromBody] Pedido value)
        {
           return Ok(_processamentoService.ProcessarProduto(value));
        }
    }
}
