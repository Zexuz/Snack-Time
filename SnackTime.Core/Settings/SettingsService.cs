using System.Linq;
using SnackTime.Core.Database;

namespace SnackTime.Core.Settings
{
    public class SettingsService
    {
        private readonly SettingsRepo _settingsRepo;

        public SettingsService(SettingsRepo settingsRepo)
        {
            _settingsRepo = settingsRepo;
        }

        public void Save(Settings settings)
        {
            _settingsRepo.Save(settings);
        }

        public Settings Get()
        {
            return _settingsRepo.Get() ?? new Settings();
        }
    }

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


    public class Settings : DbEntity
    {
        public string MpvPath { get; set; }
        public string SvpPath { get; set; }

        public string SonarrAddress { get; set; }
        public string RadarrAddress { get; set; }
    }

    public abstract class DbEntity
    {
        public int Id { get; set; }
    }
}