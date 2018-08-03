using System;

namespace MediaHelper.EventBus
{
    public interface IEventBus
    {
        void Subscribe(string queueName, EventHandler<byte[]> callback);
        void Publish(string queueName, byte[] message);
    }
}