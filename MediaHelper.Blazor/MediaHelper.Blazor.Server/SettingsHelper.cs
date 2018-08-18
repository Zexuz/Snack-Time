using System.IO;
using Newtonsoft.Json;

namespace MediaHelper.Blazor.Server
{
    public static class SettingsHelper
    {
        public static void Save(Settings settings)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\.settings", JsonConvert.SerializeObject(settings));
        }

        public static void Add(Settings settings)
        {
            var oldSettings = Load();

            SetIfEmpty(settings, oldSettings);

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\.settings", JsonConvert.SerializeObject(settings));
        }

        public static Settings Load()
        {
            return JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\.settings"));
        }
        
        private static void SetIfEmpty(Settings settings, Settings oldSettings)
        {
            if (string.IsNullOrEmpty(settings.MpcHc))
                settings.MpcHc = oldSettings.MpcHc;

            if (string.IsNullOrEmpty(settings.Radarr))
                settings.Radarr = oldSettings.Radarr;

            if (string.IsNullOrEmpty(settings.Sonarr))
                settings.Sonarr = oldSettings.Sonarr;
        }
    }
}