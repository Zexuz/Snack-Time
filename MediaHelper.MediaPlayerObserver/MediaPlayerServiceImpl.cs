using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediaHelper.Protobuf.generated;
using MPC_HC.Domain;

namespace MediaHelper.MediaPlayerObserver
{
    public class MediaPlayerServiceImpl : MediaPlayerService.MediaPlayerServiceBase
    {
        private readonly IMPCHomeCinema _mpcHomeCinemaClient;
        private          ProcessManager _processManager;
        private          string         _mpchcPath;

        public MediaPlayerServiceImpl(IMPCHomeCinema mpcHomeCinemaClient)
        {
            _mpcHomeCinemaClient = mpcHomeCinemaClient;
            _mpchcPath = @"C:\Program Files (x86)\MPC-HC\mpc-hc.exe";
            _processManager = ProcessManager.Instance;
        }

        public override async Task<EmptyMessage> Open(OpenFile request, ServerCallContext context)
        {
            if (!_processManager.IsProcessRunning(_mpchcPath))
                _processManager.StartProcess(_mpchcPath);
            
            await _mpcHomeCinemaClient.OpenFileAsync(request.FileName);
            await Task.Delay(1000);
            await _mpcHomeCinemaClient.SetPosition(TimeSpan.FromSeconds(request.FromSeconds));

            //todo here we need to close MPCHC and then reOpen it to ensure the fullscreen has not changed.
//            await _mpcHomeCinemaClient.
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