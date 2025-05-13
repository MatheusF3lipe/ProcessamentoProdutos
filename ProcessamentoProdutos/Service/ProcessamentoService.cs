using System.Text;
using Newtonsoft.Json;
using ProcessamentoProdutosAplication.Interface;
using ProcessamentoProdutosDomain.Domain;
using RabbitMQ.Client;

namespace ProcessamentoProdutosAplication.Service
{
    public class ProcessamentoService : IProcessamentoService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
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
        public void ProcessarProduto(Pedido pedido)
        {
            var body = Encoding.UTF8.GetBytes(pedido.ClienteId);
            _channel.BasicPublish(exchange: "",
                             routingKey: "pedido",
                             basicProperties: null,
                             body: body);

        }
    }
}
