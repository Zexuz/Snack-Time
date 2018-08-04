using LocalNetflix.Protobuf.MediaPlayerServices;
using MediaHelper.Protobuf.grpc;
using MPC_HC.Domain;

namespace MediaHelper.MediaPlayerObserver
{
    public class MediaPlayerServer : GrpcServerBase, IGrpcServerBase
    {
        public MediaPlayerServer(string ip, int port, IMPCHomeCinema mpcHomeCinema) :
            base(MediaPlayerService.BindService(new MediaPlayerServiceImpl(mpcHomeCinema)), ip, port)
        {
        }
    }
}