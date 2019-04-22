using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Storage.ProtoGenerated;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi
{
    public class MediaPlayerObserver : IHostedService
    {
        private readonly Queue<Item>         _queue;
        private readonly SessionFactory      _sessionFactory;
        private readonly IApi                _api;
        private readonly TimeService         _timeService;
        private readonly ISessionRepoFactory _sessionRepoFactory;

        private CancellationToken _token;
        private Task              _task;

        public MediaPlayerObserver
        (
            Queue<Item> queue,
            SessionFactory sessionFactory,
            IApi api, TimeService timeService,
            ISessionRepoFactory sessionRepoFactory
        )
        {
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

                if (_queue.HasItems())
                {
                    if (currentSession != null)
                    {
                        //update the current session before overiing it
                    }

                    var item = _queue.Pop();
                    await _api.ShowText($"Now playing {item.Path.Substring(item.Path.LastIndexOf('\\') + 1)}", TimeSpan.FromSeconds(5));
                    await _api.PlayMedia(item.Path);
                    var duration = await _api.GetDuration();
                    currentSession = _sessionFactory.CreateNewSession(item.MediaFileId, duration);
                }

                if (currentSession != null)
                {
                    currentSession.Duration.EndPostionInSec = (await _api.GetCurrentPosition()).TotalSeconds;
                    currentSession.EndUTC = _timeService.GetCurrentTimeAsUnixSeconds();

                    var sessionRepo = await _sessionRepoFactory.GetRepo();
                    await sessionRepo.UpsertSession(currentSession);
                }

                //How do we create a new WatchSession?
                // Add a WatchQueue, the rest endpoint insted of starting the service
                // it adds the request to a queue, and here we look for that queue
                // And for every new Request, we create a new watchSession

                // And if we are already playing a video, and receive a new item in out queue,
                // We replaces the media playing and add a new watch session
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _token = cancellationToken;
            return Task.CompletedTask;
        }
    }
}