using System;
using System.Text;
using System.Threading.Tasks;
using MpcHcObserver;
using MpcHcObserver.Events;
using MPC_HC.Domain;
using RabbitMQ.Client;

namespace LocalNetflix.MediaPlayerObserver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "http://localhost:13579";

            var mpcClient = new MPCHomeCinema(url);

            StartGrpcServer("localhost", 50051, mpcClient);
            await StartAndSetupEventSystem(mpcClient);
        }

        private static async Task StartAndSetupEventSystem(MPCHomeCinema mpcClient)
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

                await StartAndSetupMpcHcObserver(mpcClient, channel);

                Console.ReadLine();
            }
        }

        private static async Task StartAndSetupMpcHcObserver(MPCHomeCinema mpcClient, IModel channel)
        {
            var mpcHcObserver = new Observer(mpcClient);

            mpcHcObserver.StateChanged += (sender, eventArgs) => PropChanged(sender, eventArgs, channel);
            mpcHcObserver.PositionChanged += (sender, eventArgs) => PropChanged(sender, eventArgs, channel);
            mpcHcObserver.NewMediaFileLoaded += (sender, eventArgs) => PropChanged(sender, eventArgs, channel);

            await mpcHcObserver.Start();
        }

        private static void StartGrpcServer(string ip, int port, MPCHomeCinema mpcClient)
        {
            var server = new MediaPlayerServer(ip, port, mpcClient);

            server.Start();
            Console.WriteLine($"Started GRPC server on {ip}:{port}");
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