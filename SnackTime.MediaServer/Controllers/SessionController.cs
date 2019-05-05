using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Service.Session;

namespace SnackTime.MediaServer.Controllers
{
    public class SessionController : Session.SessionBase
    {
        private readonly ILocalSessionRepo _localSessionRepo;

        public SessionController(ILocalSessionRepo localSessionRepo)
        {
            _localSessionRepo = localSessionRepo;
        }

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var sessions = await _localSessionRepo.GetAll();
            return new GetAllResponse
            {
                Sessions = {sessions}
            };
        }

        public override async Task<UpsertResponse> Upsert(UpsertRequest request, ServerCallContext context)
        {
            await _localSessionRepo.UpsertSession(request.Session);
            return new UpsertResponse();
        }
    }
}