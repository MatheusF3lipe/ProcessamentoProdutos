using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessamentoProdutosDomain.Domain;

namespace ProcessamentoProdutosAplication.Interface
{
    public interface IProcessamentoService
    {
        public string ProcessarProduto(Pedido pedido);
        public List<string> VerificarProcessamento();
    }
}
