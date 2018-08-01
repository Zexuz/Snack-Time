using System;
using System.Threading.Tasks;
using Grpc.Core;
using LocalNetflix.Protobuf.MediaPlayerModels;
using LocalNetflix.Protobuf.MediaPlayerServices;
using LocalNetflix.Protobuf.MiscModels;
using MPC_HC.Domain;

namespace LocalNetflix.MediaPlayerObserver
{
    public class MediaPlayerServiceImpl : MediaPlayerService.MediaPlayerServiceBase
    {
        private readonly IMPCHomeCinema _mpcHomeCinemaClient;

        public MediaPlayerServiceImpl(IMPCHomeCinema mpcHomeCinemaClient)
        {
            _mpcHomeCinemaClient = mpcHomeCinemaClient;
        }

        public override async Task<PlayingMediaInfo> Info(EmptyMessage request, ServerCallContext context)
        {
            var info = await _mpcHomeCinemaClient.GetInfo();

            var model = new PlayingMediaInfo
            {
                Duration = (int) info.Duration.TotalSeconds,
                Eplipsed = (int) info.Position.TotalSeconds,
                FileName = info.FileName,
            };

            switch (info.State)
            {
                case State.Stoped:
                    model.State = Protobuf.MediaPlayerModels.State.Stoped;
                    break;
                case State.Playing:
                    model.State = Protobuf.MediaPlayerModels.State.Playing;
                    break;
                case State.Paused:
                    model.State = Protobuf.MediaPlayerModels.State.Paused;
                    break;
                case State.None:
                    model.State = Protobuf.MediaPlayerModels.State.Unknown;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            return model;
        }
    }
}