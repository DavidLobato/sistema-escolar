using RabbitMQ.Client;
using System.Text;


namespace SistemaEscolar.Infrastructure.RabbitMQ
{
    public class RabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService(string hostname)
        {
            var factory = new ConnectionFactory() { HostName = hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "sistemaescolar",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: "sistemaescolar",
                                 basicProperties: null,
                                 body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
