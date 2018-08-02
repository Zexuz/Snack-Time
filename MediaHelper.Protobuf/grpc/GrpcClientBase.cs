using System;
using Grpc.Core;

namespace MediaHelper.Protobuf.grpc
{
    public abstract class GrpcClientBase
    {
        public string Ip   { get; }
        public int    Port { get; }

        private Channel _channel;
        
        protected GrpcClientBase(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }
        
        protected void Start()
        {
            _channel = new Channel($"{Ip}:{Port}", ChannelCredentials.Insecure);
        }
        
        protected Channel GetChannel()
        {
            if(_channel == null)
                throw new Exception("Must call Start before getting the channel");

            return _channel;
        }
        
        public void Shutdown()
        {
            _channel.ShutdownAsync().Wait();
        }
    }
}