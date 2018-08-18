using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediaHelper.Protobuf.grpc.Models;

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
            if (_channel == null)
                throw new Exception("Must call Start before getting the channel");

            return _channel;
        }

        public void Shutdown()
        {
            _channel.ShutdownAsync().Wait();
        }

        protected static async Task<GrpcResponse<TEntity>> ExecuteAsync<TEntity>(AsyncUnaryCall<TEntity> action) where TEntity : class
        {
            try
            {
                var response = await action;
                return CreateResponse(response);
            }
            catch (RpcException e)
            {
                return HandleError<TEntity>(e);
            }
        }

//        protected static async Task<GrpcResponse<TEntity>> Execute<TEntity>(Func<Task<TEntity>> action) where TEntity : class
//        {
//            try
//            {
//                var response = await action();
//                return CreateResponse(response);
//            }
//            catch (RpcException e)
//            {
//                return HandleError<TEntity>(e);
//            }
//        }

        protected virtual DateTime GetDeadline()
        {
#if DEBUG
            return DateTime.UtcNow.AddMilliseconds(100000);
#else
            return DateTime.UtcNow.AddMilliseconds(500);
#endif
        }

        private static GrpcResponse<T> CreateResponse<T>(T response) where T : class
        {
            return new GrpcResponse<T>(response, GrpcError.None);
        }


        private static GrpcResponse<T> HandleError<T>(RpcException e) where T : class
        {
            switch (e.StatusCode)
            {
                case StatusCode.Cancelled:
                case StatusCode.Unknown:
                case StatusCode.InvalidArgument:
                case StatusCode.NotFound:
                case StatusCode.AlreadyExists:
                case StatusCode.PermissionDenied:
                case StatusCode.Unauthenticated:
                case StatusCode.ResourceExhausted:
                case StatusCode.FailedPrecondition:
                case StatusCode.Aborted:
                case StatusCode.OutOfRange:
                case StatusCode.Internal:
                case StatusCode.Unimplemented:
                case StatusCode.DataLoss:
                    return new GrpcResponse<T>(GrpcError.Unknown);
                case StatusCode.DeadlineExceeded:
                    return new GrpcResponse<T>(GrpcError.DeadlineExceededOrOffline);
                case StatusCode.Unavailable:
                    return new GrpcResponse<T>(GrpcError.Offline);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}