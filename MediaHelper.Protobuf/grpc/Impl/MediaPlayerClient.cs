using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediaHelper.Protobuf.generated;
using MediaHelper.Protobuf.grpc.Models;

namespace MediaHelper.Protobuf.grpc.Impl
{
    public class MediaPlayerClient : GrpcClientBase
    {
        private readonly MediaPlayerService.MediaPlayerServiceClient _client;

        public MediaPlayerClient(string ip, int port) : base(ip, port)
        {
            Start();
            _client = new MediaPlayerService.MediaPlayerServiceClient(GetChannel());
        }

        public async Task<GrpcResponse<PlayingMediaInfo>> Info()
        {
            try
            {
                return new GrpcResponse<PlayingMediaInfo>(await _client.InfoAsync(new EmptyMessage(), deadline: GetDeadline()), GrpcError.None);
            }
            catch (RpcException e)
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
                        return new GrpcResponse<PlayingMediaInfo>(GrpcError.Unknown);
                    case StatusCode.DeadlineExceeded:
                        return new GrpcResponse<PlayingMediaInfo>(GrpcError.DeadlineExceededOrOffline);
                    case StatusCode.Unavailable:
                        return new GrpcResponse<PlayingMediaInfo>(GrpcError.Offline);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static DateTime GetDeadline()
        {
            return DateTime.UtcNow.AddMilliseconds(500);
        }
    }
}