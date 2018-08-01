﻿using LocalNetflix.Grpc;
using LocalNetflix.Protobuf.MediaPlayerServices;
using MPC_HC.Domain;

namespace LocalNetflix.MediaPlayerObserver
{
    public class MediaPlayerServer : GrpcServerBase, IGrpcServerBase
    {
        public MediaPlayerServer(string ip, int port, IMPCHomeCinema mpcHomeCinema) :
            base(MediaPlayerService.BindService(new MediaPlayerServiceImpl(mpcHomeCinema)), ip, port)
        {
        }
    }
}