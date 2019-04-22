using System.Collections.Generic;
using System.Threading.Tasks;
using SnackTime.Core.Database;
using SnackTime.Core.Session;

namespace SnackTime.Core
{
    public class LocalSessionRepo : ILocalSessionRepo, IRemoteSessionRepo
    {
        private readonly DatabaseFactory _databaseFactory;

        public LocalSessionRepo(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public Task UpsertSession(MediaServer.Storage.ProtoGenerated.Session session)
        {
            using (var db = _databaseFactory.GetRepository())
            {
                db.Upsert(session);
            }

            return Task.CompletedTask;
        }

        public Task<List<MediaServer.Storage.ProtoGenerated.Session>> GetAll()
        {
            using (var db = _databaseFactory.GetRepository())
            {
                var sessions = db.Fetch<MediaServer.Storage.ProtoGenerated.Session>();
                return Task.FromResult(sessions);
            }
        }
    }
}