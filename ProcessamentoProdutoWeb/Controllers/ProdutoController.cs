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
        [HttpGet("Processamento de pedidos")]
        public async Task<List<string>> Get()
        {
            await Task.Delay(2000);
            return _processamentoService.VerificarProcessamento();
 
        }


        // POST api/<ProdutoController>
        [HttpPost("NovoProduto")]
        public string Post([FromBody] Pedido value)
        {
           return _processamentoService.ProcessarProduto(value);
        }
    }
}
