using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Models.ProtoGenerated;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.WebApi
{
    public class MediaPlayerObserver : IHostedService
    {
        private readonly Queue<Item>    _queue;
        private readonly SessionService _sessionService;
        private readonly IApi           _api;
        private readonly TimeService _timeService;

        private CancellationToken _token;
        private Task              _task;

        public MediaPlayerObserver(Queue<Item> queue, SessionService sessionService, IApi api, TimeService timeService)
        {
            _queue = queue;
            _sessionService = sessionService;
            _api = api;
            _timeService = timeService;
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
                    currentSession = _sessionService.CreateNewSession(item.MediaFileId, duration);
                }

                if (currentSession != null)
                {
                    currentSession.Duration.EndPostionInSec = (await _api.GetCurrentPosition()).TotalSeconds;
                    currentSession.EndUTC = _timeService.GetCurrentTimeAsUnixSeconds();
                    _sessionService.UpsertSession(currentSession);
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