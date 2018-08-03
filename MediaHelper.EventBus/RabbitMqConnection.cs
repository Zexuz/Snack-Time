using RabbitMQ.Client;

namespace MediaHelper.EventBus
{
    public class RabbitMqConnection : IEventBusConnection
    {
        public IConnection Connection => _factory.CreateConnection();

        private ConnectionFactory _factory;

        public RabbitMqConnection(string hostName)
        {
            _factory = new ConnectionFactory {HostName = hostName};
        }
    }
}