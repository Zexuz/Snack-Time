using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core;
using SnackTime.Core.Database;
using SnackTime.Core.Session;
using SnackTime.Core.Settings;
using SnackTime.MediaServer.Service.Status;
using Status = SnackTime.MediaServer.Service.Status.Status;

namespace SnackTime.WebApi.Services
{
    public class StatusService
    {
        private readonly ILogger<StatusService> _logger;
        private readonly SettingsService        _settingsService;
        private readonly Status.StatusClient    _statusClient;

        public StatusService(ILogger<StatusService> logger, GrpcClientProvider clientProvider, SettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
            _statusClient = clientProvider.GetStatusClient();
        }

        public async Task<bool> IsOnline()
        {
            if (!_settingsService.Get().Remote.IsOnline)
            {
                _logger.LogDebug("Remote is not enabled");
                return false;
            }

            try
            {
                await _statusClient.PingAsync(new PingRequest(), deadline: DateTime.UtcNow.AddSeconds(2));
                _logger.LogDebug("Media server is up and running");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogDebug("Could not connect to the media server");
                return false;
            }
        }
    }
}