using Microsoft.Extensions.Logging;

namespace SnackTime.Core.Settings
{
    public class SettingsService
    {
        private readonly ILogger<SettingsService> _logger;
        private readonly SettingsRepo             _settingsRepo;

        public SettingsService(ILogger<SettingsService> logger, SettingsRepo settingsRepo)
        {
            _logger = logger;
            _settingsRepo = settingsRepo;
        }

        public void Save(App.Settings.ProtoGenerated.Settings settings)
        {
            _logger.LogTrace($"Saving settings {settings}");
            _settingsRepo.Save(new Settings
            {
                Id = 1,
                Value = settings,
            });
        }

        public App.Settings.ProtoGenerated.Settings Get()
        {
            return _settingsRepo.Get()?.Value ?? new App.Settings.ProtoGenerated.Settings();
        }
    }
}