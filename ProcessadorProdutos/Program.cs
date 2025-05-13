using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory() { HostName = "localhost" };

using (var conn = factory.CreateConnection())
using (var channel = conn.CreateModel())
{
    channel.QueueDeclare(queue: "pedido",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        Thread.Sleep(5000); // Simula o processamento do pedido
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" Processando {message}");
    };
    channel.BasicConsume(queue: "pedido",
                         autoAck: true,
                         consumer: consumer);
    Console.WriteLine(" Aperte X para sair");
    Console.ReadLine();
}