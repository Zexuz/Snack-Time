using System.Threading.Tasks;
using LocalNetflix.Protobuf.generated;

namespace LocalNetflix.Grpc.Grpc
{
    public class MediaPlayerClient:GrpcClientBase
    {
        private MediaPlayerService.MediaPlayerServiceClient _client;

        public MediaPlayerClient(string ip, int port) : base(ip,port)
        {
            Start();
            _client = new MediaPlayerService.MediaPlayerServiceClient(GetChannel());
        }
        
        public async Task<PlayingMediaInfo> Info()
        {
            return await _client.InfoAsync(new EmptyMessage());
        }
    }
}