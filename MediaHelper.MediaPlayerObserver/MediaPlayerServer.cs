using MediaHelper.Protobuf.generated;
using MediaHelper.Protobuf.grpc;

namespace MediaHelper.MediaPlayerObserver
{
    public class MediaPlayerServer : GrpcServerBase, IGrpcServerBase
    {
        public MediaPlayerServer(string ip,int port, MediaPlayerService.MediaPlayerServiceBase mediaPlayerServiceImpl) :base(MediaPlayerService.BindService(mediaPlayerServiceImpl),ip,port)
        {
        }
    }
}