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
        // GET: api/<ProdutoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutoController>
        [HttpPost("NovoProduto")]
        public void Post([FromBody] Pedido value)
        {
            _processamentoService.ProcessarProduto(value);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
