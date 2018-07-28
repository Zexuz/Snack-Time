using System;
using System.Text;
using System.Threading.Tasks;
using MpcHcObserver;
using MpcHcObserver.Events;
using RabbitMQ.Client;

namespace LocalNetflix.MediaPlayerObserver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var observer = new Observer();

                observer.StateChanged += (sender, eventArgs) => PropChanged(sender,eventArgs,channel);
                observer.PositionChanged += (sender, eventArgs) => PropChanged(sender,eventArgs,channel);
                observer.NewMediaFileLoaded+= (sender, eventArgs) => PropChanged(sender,eventArgs,channel);

                await observer.Start();

                Console.ReadLine();
            }
        }

        private static void PropChanged<T>(object sender, GenericPropertyChangedEventArgs<T> e, IModel channel)
        {
            SendMessage($"Went from [{e.OldValue.ToString()}] -> [{e.NewValue.ToString()}]", channel);
        }

        public static void SendMessage(string message, IModel channel)
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                routingKey: "hello",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}