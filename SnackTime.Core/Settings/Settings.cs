using SnackTime.Core.Database;

namespace SnackTime.Core.Settings
{
    public class Settings : DbEntity
    {
        public string MpvPath { get; set; }
        public string SvpPath { get; set; }

        public string SonarrAddress { get; set; }
        public string RadarrAddress { get; set; }
    }
}