namespace LocalNetflix.Grpc
{
    public interface IGrpcServerBase
    {
        void Start();
        void Shutdown();
    }
}