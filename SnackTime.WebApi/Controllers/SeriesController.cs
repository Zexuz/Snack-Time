using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackTime.Core.Series;
using SonarrSharp;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Series : ControllerBase
    {
        private readonly SeriesProvider _seriesProvider;

        public Series(SonarrClient client)
        {
            _seriesProvider = new SeriesProvider(client);
        }

        [HttpGet("")]
        public async Task<ActionResult> GetSeries()
        {
            var series = await _seriesProvider.GetSeries();
            return Ok(ApiResponseFactory.CreateSuccess(series));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSeriesById(int id)
        {
            var series = await _seriesProvider.GetSeriesById(id);
            return Ok(ApiResponseFactory.CreateSuccess(series));
        }
    }

    public static class ApiResponseFactory
    {
        public static ApiResponse<T> CreateSuccess<T>(T payload)
        {
            return new ApiResponse<T>
            {
                Payload = payload,
                Success = true,
                Error = null,
            };
        }
    }

    public class ApiResponse<T>
    {
        public bool      Success { get; set; }
        public T         Payload { get; set; }
        public Exception Error   { get; set; }
    }
}