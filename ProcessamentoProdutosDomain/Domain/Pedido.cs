using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoProdutosDomain.Domain
{
    public class Pedido
    {
        public string? ClienteId { get; set; }
        public List<String>? Itens { get; set; }
    }
}
