using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Storage.ProtoGenerated;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi
{
    public class MediaPlayerObserver : IHostedService
    {
        private readonly ILogger<MediaPlayerObserver> _logger;
        private readonly Queue<Item>                  _queue;
        private readonly SessionFactory               _sessionFactory;
        private readonly IApi                         _api;
        private readonly TimeService                  _timeService;
        private readonly ISessionRepoFactory          _sessionRepoFactory;

        private CancellationToken _token;
        private Task              _task;

        public MediaPlayerObserver
        (
            ILogger<MediaPlayerObserver> logger,
            Queue<Item> queue,
            SessionFactory sessionFactory,
            IApi api, TimeService timeService,
            ISessionRepoFactory sessionRepoFactory
        )
        {
            _logger = logger;
            _queue = queue;
            _sessionFactory = sessionFactory;
            _api = api;
            _timeService = timeService;
            _sessionRepoFactory = sessionRepoFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _task = Tick();
            return Task.CompletedTask;
        }

        private async Task Tick()
        {
            Session currentSession = null;
            while (!_token.IsCancellationRequested)
            {
                await Task.Delay(500 * 1, _token);

                if (currentSession != null)
                {
                    try
                    {
                        await UpdateCurrentSession(currentSession);
                    }
                    catch (Exception e)
                    {
                        // after we crash, we come back with the last session, but it hangs. Then MPV comes back up, we update the last session with the new values. BAD!!!!
                        //TODO Here we need to know why we got the exception? Is mpv still running? 
                        _logger.LogWarning(e, "Received error when trying to get current position");
                        currentSession = null;
                    }
                }

                if (!_queue.HasItems()) continue;

                var item = _queue.Pop();
                await _api.PlayMedia(item.Path, item.StartPosition);
                await _api.ShowText($"Now playing {item.Path.Substring(item.Path.LastIndexOf('\\') + 1)}", TimeSpan.FromSeconds(5));

                var duration = await _api.GetDuration();
                currentSession = _sessionFactory.CreateNewSession(item.MediaFileId, duration);
            }
        }

        private async Task UpdateCurrentSession(Session currentSession)
        {
            currentSession.Duration.EndPostionInSec = (await _api.GetCurrentPosition()).TotalSeconds;
            currentSession.EndUTC = _timeService.GetCurrentTimeAsUnixSeconds();

            var sessionRepo = await _sessionRepoFactory.GetRepo();
            await sessionRepo.UpsertSession(currentSession);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _token = cancellationToken;
            return Task.CompletedTask;
        }
    }
}