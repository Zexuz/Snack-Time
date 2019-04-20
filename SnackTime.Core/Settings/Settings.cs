using SnackTime.Core.Database;

namespace SnackTime.Core.Settings
{
    public class Settings : DbEntity
    {
        public App.Settings.ProtoGenerated.Settings Value { get; set; }
    }
}