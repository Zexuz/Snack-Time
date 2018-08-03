using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MediaHelper.EventBus
{
    public class RabbitMqEventBus : IEventBus
    {
        private readonly IModel _channel;

        public RabbitMqEventBus(IEventBusConnection connection)
        {
            _channel = connection.Connection.CreateModel();
        }

        public void Subscribe(string queueName, EventHandler<byte[]> callback)
        {
            DeclareQueue(queueName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, args) => callback.Invoke(sender, args.Body);

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        public void Publish(string queueName, byte[] message)
        {
            DeclareQueue(queueName);

            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: message);
        }


        private void DeclareQueue(string queueName)
        {
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}