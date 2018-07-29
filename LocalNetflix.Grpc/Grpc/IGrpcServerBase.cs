namespace LocalNetflix.Grpc.Grpc
{
    public interface IGrpcServerBase
    {
        void Start();
        void Shutdown();
    }
}