using System;
using System.Linq;
using SnackTime.Core.Database;
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
            MediaFileId mediaFileId,
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
                MediaId = mediaFileId.ToString(),
                Duration = timeWatched,
                StartUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                EndUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                MediaLenghtInSec = mediaDuration.TotalSeconds,
            };
            return session;
        }
    }
}