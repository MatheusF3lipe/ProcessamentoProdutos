using System.Text;
using ProcessamentoProdutosAplication.Interface;
using ProcessamentoProdutosDomain.Domain;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProcessamentoProdutosAplication.Service
{
    public class ProcessamentoService : IProcessamentoService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private List<string> lista = new List<string>();
        public ProcessamentoService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "pedido",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        }
        public string ProcessarProduto(Pedido pedido)
        {
            Guid guidCliente = Guid.NewGuid();
            var body = Encoding.UTF8.GetBytes(guidCliente.ToString());
            _channel.BasicPublish(exchange: "",
                             routingKey: "pedido",
                             basicProperties: null,
                             body: body);
            Console.WriteLine($"{guidCliente} -- Em processamento");
            return $"{pedido.ClienteId} foi encaminhado para o processamento com a id única {guidCliente}. Consulte no método get para verificar o processamento!";
        }

        public List<string> VerificarProcessamento()
        {
            var consumer = new EventingBasicConsumer(_channel);
            var resultado = _channel.BasicGet("pedido", true);
            while (resultado != null)
            {
                var body = resultado.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                lista.Add(message);
                Console.WriteLine($"{message} - Processado");
                resultado = _channel.BasicGet("pedido", true);
            }
            return lista.Select(x => x += " - Processado").ToList();
        }
    }
}
