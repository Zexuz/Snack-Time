namespace MediaHelper.Protobuf.grpc
{
    public interface IGrpcServerBase
    {
        void Start();
        void Shutdown();
    }
}