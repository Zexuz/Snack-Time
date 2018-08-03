using RabbitMQ.Client;

namespace MediaHelper.EventBus
{
    public interface IEventBusConnection
    {
        IConnection Connection { get; }
    }
}