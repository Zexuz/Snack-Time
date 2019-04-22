using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Service.Session;

namespace SnackTime.WebApi.Services
{
    public class SessionSyncService
    {
        private readonly ILogger<SessionSyncService> _logger;
        private readonly SessionService              _sessionService;
        private readonly Session.SessionClient       _sessionClient;

        public SessionSyncService(ILogger<SessionSyncService> logger, SessionService sessionService, Session.SessionClient sessionClient)
        {
            _logger = logger;
            _sessionService = sessionService;
            _sessionClient = sessionClient;
        }

        public async Task Sync()
        {
            _logger.LogInformation("Starting sync of sessions");
            var sessions = _sessionService.GetAll();
            var response = await _sessionClient.GetAllAsync(new GetAllRequest());

            _logger.LogDebug($"Have {sessions.Count} sessions locally");
            _logger.LogDebug($"Have {response.Sessions.Count} sessions on server");

            foreach (var session in sessions)
            {
                _logger.LogDebug($"Upsert {session.Id} to server");
                _sessionClient.Upsert(new UpsertRequest
                {
                    Session = session
                });
            }

            foreach (var session in response.Sessions)
            {
                _logger.LogDebug($"Upsert {session.Id} locally");
                _sessionService.UpsertSession(session);
            }
        }
    }
}