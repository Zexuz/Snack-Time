using System;
using System.Linq;
using SnackTime.Core.Database;
using SnackTime.Core.Media;
using SnackTime.MediaServer.Service.Session;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.Core.Session
{
    public class SessionFactory
    {
        private readonly TimeService _timeService;

        public SessionFactory(TimeService timeService)
        {
            _timeService = timeService;
        }

        public MediaServer.Storage.ProtoGenerated.Session CreateNewSession
        (
            MediaId mediaId,
            PlayableId playableId,
            TimeSpan mediaDuration,
            TimeSpan? startPosition = null
        )
        {
            var timeWatched = new Duration {EndPostionInSec = 0, StartPostionInSec = 0};
            if (startPosition.HasValue)
            {
                timeWatched.StartPostionInSec = startPosition.Value.TotalSeconds;
                timeWatched.EndPostionInSec = startPosition.Value.TotalSeconds;
            }

            var session = new MediaServer.Storage.ProtoGenerated.Session
            {
                Id = Guid.NewGuid().ToString("N"),
                FileId = playableId.ToString(),
                MediaId = mediaId.ToString(),
                Duration = timeWatched,
                StartUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                EndUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                MediaLenghtInSec = mediaDuration.TotalSeconds,
            };
            return session;
        }
    }
}