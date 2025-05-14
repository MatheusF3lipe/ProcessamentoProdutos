namespace ProcessamentoProdutosDomain.Domain
{
    public class Pedido
    {
        public string? ClienteId { get; set; }
        public List<String>? Itens { get; set; }
    }
}
