using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.MediaServer.Service.Status;
using Status = SnackTime.MediaServer.Service.Status.Status;

namespace SnackTime.MediaServer.Controllers
{
    public class StatusController : Status.StatusBase
    {
        public override Task<PingResponse> Ping(PingRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PingResponse());
        }
    }
}