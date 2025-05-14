using Microsoft.AspNetCore.Mvc;
using ProcessamentoProdutosAplication.Interface;
using ProcessamentoProdutosDomain.Domain;


namespace ProcessamentoProdutoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProcessamentoService processamentoService) : ControllerBase
    {
        private readonly IProcessamentoService _processamentoService = processamentoService;
        [HttpGet("Pedido/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(2000);
            var pedidosProcesssados = _processamentoService.VerificarProcessamento().Result.Where(x => x == id).FirstOrDefault();
            return String.IsNullOrEmpty(pedidosProcesssados) ? NotFound($"Pedido com id {id} não encontrado.") : Ok($"{pedidosProcesssados} -- Processada!");
        }

        // POST api/<ProdutoController>
        [HttpPost("pedidos")]
        public async Task<IActionResult> Post([FromBody] Pedido value)
        {
            var pedido = await _processamentoService.ProcessarProduto(value);
           return Ok(pedido);
        }
    }
}
