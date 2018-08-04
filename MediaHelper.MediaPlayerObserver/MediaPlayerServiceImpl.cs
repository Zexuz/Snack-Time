using System;
using System.Threading.Tasks;
using Grpc.Core;
using LocalNetflix.Protobuf.MediaPlayerModels;
using LocalNetflix.Protobuf.MediaPlayerServices;
using LocalNetflix.Protobuf.MiscModels;
using MPC_HC.Domain;

namespace MediaHelper.MediaPlayerObserver
{
    public class MediaPlayerServiceImpl : MediaPlayerService.MediaPlayerServiceBase
    {
        private readonly IMPCHomeCinema _mpcHomeCinemaClient;

        public MediaPlayerServiceImpl(IMPCHomeCinema mpcHomeCinemaClient)
        {
            _mpcHomeCinemaClient = mpcHomeCinemaClient;
        }

        public override async Task<EmptyMessage> Open(OpenFile request, ServerCallContext context)
        {
            await _mpcHomeCinemaClient.OpenFileAsync(request.FileName);
            return new EmptyMessage();
        }

        public override async Task<PlayingMediaInfo> Info(EmptyMessage request, ServerCallContext context)
        {
            var info = await _mpcHomeCinemaClient.GetInfo();

            var model = new PlayingMediaInfo
            {
                Duration = (int) info.Duration.TotalSeconds,
                Eplipsed = (int) info.Position.TotalSeconds,
                FileName = info.FileName,
                State = info.State.Convert(),
            };

            return model;
        }
    }
}