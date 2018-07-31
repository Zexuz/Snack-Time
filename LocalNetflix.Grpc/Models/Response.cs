using System.ComponentModel;

namespace LocalNetflix.Grpc.Models
{
    public class GrpcResponse<TResponse> where TResponse : class
    {
        public TResponse Response { get; }
        public GrpcError Error    { get; }
        public bool      IsError  => Error != GrpcError.None;

        public GrpcResponse(TResponse response, GrpcError error)
        {
            Response = response;
            Error = error;
        }

        public GrpcResponse(GrpcError error) : this(null, error)
        {
        }
    }

    public enum GrpcError
    {
        None,
        Unknown,
        Offline,
        DeadlineExceededOrOffline,
    }
}