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

        public void Save(Settings settings)
        {
            _logger.LogTrace($"Saving settings {settings}");
            _settingsRepo.Save(settings);
        }

        public Settings Get()
        {
            return _settingsRepo.Get() ?? new Settings();
        }
    }
}