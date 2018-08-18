using System;
using System.Threading.Tasks;
using Grpc.Core;
using MediaHelper.Protobuf.generated;
using MPC_HC.Domain;

namespace MediaHelper.MediaPlayerObserver
{
    public class MediaPlayerServiceImpl : MediaPlayerService.MediaPlayerServiceBase
    {
        public static event EventHandler InitEvent;
        
        
        private readonly IMPCHomeCinema _mpcHomeCinemaClient;
        private readonly Func<Task> _init;
        private readonly Func<Task> _stop;
        private readonly Func<Task> _start;
        private readonly ProcessManager _processManager;
        private          string         _mpchcPath;

        public MediaPlayerServiceImpl(IMPCHomeCinema mpcHomeCinemaClient,Func<Task> init, Func<Task> stop, Func<Task> start)
        {
            _mpcHomeCinemaClient = mpcHomeCinemaClient;
            _init = init;
            _stop = stop;
            _start = start;
            _processManager = ProcessManager.Instance;
        }

        public override async Task<EmptyMessage> Init(Init request, ServerCallContext context)
        {
            _mpchcPath = request.MediaPlayerPath;
            await _init();
            return new EmptyMessage();
        }

        public override async Task<EmptyMessage> Start(EmptyMessage request, ServerCallContext context)
        {
            _processManager.StartProcess(_mpchcPath);

            while (_processManager.IsProcessRunning(_mpchcPath))
            {
                try
                {
                    await Task.Delay(500);
                    await _start();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("MPC-HC not stared yet");
                }
            }

            return new EmptyMessage();
        }

        public override Task<IsRunning> IsRunning(EmptyMessage request, ServerCallContext context)
        {
            return Task.FromResult(new IsRunning
            {
                Value = _processManager.IsProcessRunning(_mpchcPath)
            });
        }

        public override async Task<EmptyMessage> Stop(EmptyMessage request, ServerCallContext context)
        {
            _processManager.StopProcess(_mpchcPath);
            await _stop();
            return new EmptyMessage();
        }

        public override async Task<EmptyMessage> Open(OpenFile request, ServerCallContext context)
        {
            await _mpcHomeCinemaClient.OpenFileAsync(request.FileName);
            await Task.Delay(1000);
            await _mpcHomeCinemaClient.SetPosition(TimeSpan.FromSeconds(request.FromSeconds)); //todo does not work!!?!?!
            await _mpcHomeCinemaClient.ToggleFullscreen();

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