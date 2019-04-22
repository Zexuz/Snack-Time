using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Session;
using SnackTime.Core.Settings;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.WebApi.Services
{
    public class SessionSyncService
    {
        private readonly ILogger<SessionSyncService> _logger;
        private readonly ILocalSessionRepo           _localSessionRepo;
        private readonly IRemoteSessionRepo          _remoteSessionRepo;
        private readonly SettingsService             _settingsService;

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
            var localSessions = (await _localSessionRepo.GetAll()).ToDictionary(session => session.Id);
            var remoteSessions = (await _remoteSessionRepo.GetAll()).ToDictionary(session => session.Id);

            _logger.LogDebug($"Have {localSessions.Count} sessions locally");
            _logger.LogDebug($"Have {remoteSessions.Count} sessions on server");

            await SyncDbs(localSessions, remoteSessions);
        }

        private async Task SyncDbs(Dictionary<string, Session> localSessions, Dictionary<string, Session> remoteSessions)
        {
            foreach (var key in localSessions.Keys)
            {
                if (remoteSessions.ContainsKey(key))
                {
                    if (localSessions[key].EndUTC > remoteSessions[key].EndUTC)
                    {
                        _logger.LogDebug($"Upsert {key} to server");
                        await _remoteSessionRepo.UpsertSession(localSessions[key]);
                    }
                    else
                    {
                        await _localSessionRepo.UpsertSession(remoteSessions[key]);
                        _logger.LogDebug($"Getting {key} from server to save locally");
                    }
                }
                else
                {
                    _logger.LogDebug($"Upsert {key} to server");
                    await _remoteSessionRepo.UpsertSession(localSessions[key]);
                }
            }

            foreach (var key in remoteSessions.Keys)
            {
                if (localSessions.ContainsKey(key)) continue;
                
                await _localSessionRepo.UpsertSession(remoteSessions[key]);
                _logger.LogDebug($"Getting {key} from server to save locally");
            }
        }
    }
}