using System;
using System.Threading.Tasks;
using Google.Protobuf;
using MediaHelper.Protobuf.generated;
using MPC_HC.Domain;
using RabbitMQ.Client;

namespace MediaHelper.MediaPlayerObserver
{
    class Program
    {
        private static MPCHomeCinemaObserver _mpcHcObserver;
        private static MPCHomeCinema _mpcClient;

        static async Task Main(string[] args)
        {
            var url = "http://localhost:13579";

            _mpcClient = new MPCHomeCinema(url);

            await StartAndSetupEventSystem(_mpcClient);
        }

        private static Task StartAndSetupEventSystem(MPCHomeCinema mpcClient)
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


                _mpcHcObserver = new MPCHomeCinemaObserver(mpcClient);

                _mpcHcObserver.PropertyChanged += (sender, args) => PropChanged(args, channel);

                var port = 50051;
                var ip = "localhost";
                var server = new MediaPlayerServer(ip, port, new MediaPlayerServiceImpl(mpcClient, Init, Stop, Start));

                server.Start();
                Console.WriteLine($"Started GRPC server on {ip}:{port}");


                Console.ReadLine();
            }
            return Task.CompletedTask;
        }

        private static Task Stop()
        {
            _mpcHcObserver.Stop();
            return Task.CompletedTask;
        }

        private static async Task Start()
        {
           await _mpcHcObserver.Start();    
        }

        private static Task Init()
        {
            return Task.CompletedTask;
        }

        private static void StartGrpcServer(string ip, int port, MPCHomeCinema mpcClient)
        {
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