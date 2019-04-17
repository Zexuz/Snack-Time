using System;
using LiteDB;
using SnackTime.Core.Database;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.Core.Session
{
    public class SessionService
    {
        private readonly DatabaseFactory    _databaseFactory;
        private readonly TimeService        _timeService;
        private readonly MediaFileIdService _idService;

        public SessionService(DatabaseFactory databaseFactory, TimeService timeService, MediaFileIdService idService)
        {
            _databaseFactory = databaseFactory;
            _timeService = timeService;
            _idService = idService;
        }

        public MediaServer.Storage.ProtoGenerated.Session CreateNewSession(
            int fileId,
            MediaServer.Models.ProtoGenerated.Providers provider,
            TimeSpan? startPosition = null
        )
        {
            var duration = new Duration {EndPostionInSec = 0, StartPostionInSec = 0};
            if (startPosition.HasValue)
            {
                duration.StartPostionInSec = startPosition.Value.TotalSeconds;
                duration.EndPostionInSec = startPosition.Value.TotalSeconds;
            }

            var sessionId = Guid.NewGuid().ToString("N");
            return new MediaServer.Storage.ProtoGenerated.Session
            {
                Id = sessionId,
                MediaId = _idService.GenerateId(fileId, provider),
                Duration = duration,
                StartUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
                EndUTC = _timeService.GetCurrentTimeAsUnixSeconds(),
            };
        }

        public void UpsertSession(MediaServer.Storage.ProtoGenerated.Session session)
        {
            using (var db = _databaseFactory.GetRepository())
            {
                db.Upsert(session);
            }
        }

        public object GetAll()
        {
            using (var db = _databaseFactory.GetRepository())
            {
                return db.Fetch<MediaServer.Storage.ProtoGenerated.Session>();
            }
        }
    }
}