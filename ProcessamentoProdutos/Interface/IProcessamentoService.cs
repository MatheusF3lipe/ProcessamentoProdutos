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
        public Task <string> ProcessarProduto(Pedido pedido);
        public Task< List<string> >VerificarProcessamento();
    }
}
