using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using SnackTime.Core.Database;
using SnackTime.Core.Media;
using SnackTime.Core.Session;
using DbSession = SnackTime.MediaServer.Storage.ProtoGenerated.Session;

namespace SnackTime.Core
{
    public class LocalSessionRepo : ILocalSessionRepo, IRemoteSessionRepo
    {
        private readonly DatabaseFactory _databaseFactory;

        public LocalSessionRepo(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public Task UpsertSession(DbSession session)
        {
            using (var db = _databaseFactory.GetRepository())
            {
                db.Upsert(session);
            }

            return Task.CompletedTask;
        }

        public Task<List<DbSession>> GetAll()
        {
            using (var db = _databaseFactory.GetRepository())
            {
                var sessions = db.Fetch<DbSession>();
                return Task.FromResult(sessions);
            }
        }

        public Task<DbSession> GetLastSessionForMedia(MediaId mediaId)
        {
            List<DbSession> sessions;
            using (var db = _databaseFactory.GetRepository())
            {
                sessions = db.Fetch<DbSession>(Query.StartsWith(nameof(DbSession.MediaId), mediaId.ToString()));
            }

            var lastSession = sessions.OrderByDescending(session => session.EndUTC).FirstOrDefault();
            return Task.FromResult(lastSession);
        }
    }
}