using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Session;
using SnackTime.Core.Settings;

namespace SnackTime.WebApi.Services
{
    public class SessionSyncService
    {
        private readonly ILogger<SessionSyncService> _logger;
        private readonly ILocalSessionRepo           _localSessionRepo;
        private readonly IRemoteSessionRepo          _remoteSessionRepo;
        private readonly SettingsService _settingsService;

        public SessionSyncService
        (
            ILogger<SessionSyncService> logger,
            ILocalSessionRepo localSessionRepo,
            IRemoteSessionRepo remoteSessionRepo,
            SettingsService settingsService
        )
        {
            _logger = logger;
            _localSessionRepo = localSessionRepo;
            _remoteSessionRepo = remoteSessionRepo;
            _settingsService = settingsService;
        }

        public async Task Sync()
        {
            var settings = _settingsService.Get();
            if (!settings.Remote.IsOnline)
            {
                throw new Exception("Can't sync servers when we are offline");
            }
            
            _logger.LogInformation("Starting sync of sessions");
            var localSessions = await _localSessionRepo.GetAll();
            var remoteSessions = await _remoteSessionRepo.GetAll();

            _logger.LogDebug($"Have {localSessions.Count} sessions locally");
            _logger.LogDebug($"Have {remoteSessions.Count} sessions on server");

            foreach (var session in localSessions)
            {
                _logger.LogDebug($"Upsert {session.Id} to server");
                await _remoteSessionRepo.UpsertSession(session);
            }

            foreach (var session in remoteSessions)
            {
                _logger.LogDebug($"Upsert {session.Id} locally");
                await _localSessionRepo.UpsertSession(session);
            }
        }
    }
}