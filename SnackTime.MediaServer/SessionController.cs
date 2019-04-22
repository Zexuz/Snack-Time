using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Service.Session;

namespace SnackTime.MediaServer
{
    public class SessionController : Session.SessionBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public override Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var sessions = _sessionService.GetAll();
            return Task.FromResult(new GetAllResponse
            {
                Sessions = {sessions}
            });
        }

        public override Task<UpsertResponse> Upsert(UpsertRequest request, ServerCallContext context)
        {
            _sessionService.UpsertSession(request.Session);
            return Task.FromResult(new UpsertResponse());
        }
    }
}