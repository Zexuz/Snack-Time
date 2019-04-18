using System;
using System.Collections.Generic;
using SnackTime.Core.Database;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.Core.Session
{
    public class SessionService
    {
        private readonly DatabaseFactory _databaseFactory;
        private readonly TimeService     _timeService;

        public SessionService(DatabaseFactory databaseFactory, TimeService timeService)
        {
            _databaseFactory = databaseFactory;
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

            var sessionId = Guid.NewGuid().ToString("N");
            return new MediaServer.Storage.ProtoGenerated.Session
            {
                Id = sessionId,
                MediaId = mediaFileId.ToString(),
                Duration = timeWatched,
                StartUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                EndUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                MediaLenghtInSec = mediaDuration.TotalSeconds,
            };
        }

        public void UpsertSession(MediaServer.Storage.ProtoGenerated.Session session)
        {
            using (var db = _databaseFactory.GetRepository())
            {
                db.Upsert(session);
            }
        }

        public IList<MediaServer.Storage.ProtoGenerated.Session> GetAll()
        {
            using (var db = _databaseFactory.GetRepository())
            {
                return db.Fetch<MediaServer.Storage.ProtoGenerated.Session>();
            }
        }
    }
}