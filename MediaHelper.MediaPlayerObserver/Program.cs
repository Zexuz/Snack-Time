using System;
using System.Threading.Tasks;
using Google.Protobuf;
using LocalNetflix.Protobuf.MediaPlayerModels;
using MPC_HC.Domain;
using RabbitMQ.Client;

namespace MediaHelper.MediaPlayerObserver
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
            var mpcHcObserver = new MPCHomeCinemaObserver(mpcClient);

            mpcHcObserver.PropertyChanged += (sender, args) => PropChanged(args, channel);

            await mpcHcObserver.Start();
        }

        private static void StartGrpcServer(string ip, int port, MPCHomeCinema mpcClient)
        {
            var server = new MediaPlayerServer(ip, port, mpcClient);

            server.Start();
            Console.WriteLine($"Started GRPC server on {ip}:{port}");
        }

        private static void PropChanged(PropertyChangedEventArgs e, IModel channel)
        {
            var playingMediaInfoChanged = CreatePlayingMediaInfoChanged(e.OldInfo, e.NewInfo, e.Property.Convert());
            SendMessage(playingMediaInfoChanged.ToByteArray(), channel);
        }

        public static void SendMessage(byte[] message, IModel channel)
        {
            channel.BasicPublish(exchange: "",
                routingKey: "hello",
                basicProperties: null,
                body: message);
            Console.WriteLine(" [x] Sent size of {0}", message.Length);
        }

        private static PlayingMediaInfoChanged CreatePlayingMediaInfoChanged(Info old, Info @new, PlayingMediaInfoChanged.Types.MediaProperty prop)
        {
            return new PlayingMediaInfoChanged
            {
                Property = prop,
                MediaInfo = FromInfo(@new),
                OldMediaInfo = FromInfo(old)
            };
        }

        private static PlayingMediaInfo FromInfo(Info info)
        {
            return new PlayingMediaInfo
            {
                FileName = info.FileName,
                State = info.State.Convert(),
                Duration = info.Duration.TotalSeconds,
                Eplipsed = info.Position.TotalSeconds
            };
        }
    }
}