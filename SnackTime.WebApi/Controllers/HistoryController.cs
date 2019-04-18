using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnackTime.Core.Session;

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
        private readonly SessionService _sessionService;

        public HistoryService(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public MediaServer.Models.ProtoGenerated.Series GetLatestWatched()
        {
            var sessions = _sessionService.GetAll();

            sessions
                .OrderBy(session => session.EndUTC)
                .Select(session => session.MediaId)
                .Distinct()
                .Select(s => s);

            return null;
        }
        
    }
}