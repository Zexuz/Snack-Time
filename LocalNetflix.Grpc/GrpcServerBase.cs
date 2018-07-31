using Grpc.Core;

namespace LocalNetflix.Grpc
{
    public abstract class GrpcServerBase
    {
        public           string                  Ip   { get; }
        public           int                     Port { get; }
        private          Server                  _server;

        protected GrpcServerBase(ServerServiceDefinition serverServiceDefinition, string ip, int port)
        {
            Ip = ip;
            Port = port;

            _server = new Server
            {
                Services = {serverServiceDefinition},
                Ports = {{Ip, Port, ServerCredentials.Insecure}}
            };
        }

        public void Start()
        {
            _server.Start();
        }

        public void Shutdown()
        {
            _server.ShutdownAsync().Wait();
        }
    }
}