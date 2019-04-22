using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackTime.Core.Session;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        public HistoryController()
        {
        }

        [HttpGet("")]
        public ActionResult GetLatestWatched()
        {
            return Ok();
        }
    }

    public class HistoryService
    {
        private readonly ISessionRepoFactory _sessionRepoFactory;

        public HistoryService(ISessionRepoFactory sessionRepoFactory)
        {
            _sessionRepoFactory = sessionRepoFactory;
        }

        public async Task<MediaServer.Models.ProtoGenerated.Series> GetLatestWatched()
        {
            var sessionRepo = await _sessionRepoFactory.GetRepo();
            var sessions = await sessionRepo.GetAll();

            sessions
                .OrderBy(session => session.EndUTC)
                .Select(session => session.MediaId)
                .Distinct()
                .Select(s => s);

            return null;
        }
    }
}