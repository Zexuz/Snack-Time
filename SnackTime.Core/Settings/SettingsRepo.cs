using System.Linq;
using SnackTime.Core.Database;

namespace SnackTime.Core.Settings
{
    public class SettingsRepo
    {
        private const string CollectionName = "settxigns";

        private readonly DatabaseFactory _databaseFactory;

        public SettingsRepo(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void Save(Settings settings)
        {
            settings.Id = 1;
            using (var db = _databaseFactory.CreateDatabase())
            {
                var collection = db.GetCollection<Settings>(CollectionName);
                collection.Upsert(settings);
            }
        }

        public Settings Get()
        {
            using (var db = _databaseFactory.CreateDatabase())
            {
                var collection = db.GetCollection<Settings>(CollectionName);
                return collection.FindAll().FirstOrDefault();
            }
        }
    }
}