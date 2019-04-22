using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.Core.Media.Series;
using SnackTime.MediaServer.Service.Series;
using SonarrSharp;

namespace SnackTime.MediaServer
{
    public class SeriesController : Series.SeriesBase
    {
        private readonly SeriesProvider _seriesProvider;

        public SeriesController(SeriesProvider seriesProvider)
        {
            _seriesProvider = seriesProvider;
        }

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var series = await _seriesProvider.GetSeries();
            return new GetAllResponse
            {
                Series = {series}
            };
        }

        public override async Task<GetByIdResponse> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var series = await _seriesProvider.GetSeriesById(request.Id);
            return new GetByIdResponse
            {
                Series = series,
            };
        }

        public override async Task<GetLastDownloadedResponse> GetLastDownloaded(GetLastDownloadedRequest request, ServerCallContext context)
        {
            var series = await _seriesProvider.GetLatest();
            return new GetLastDownloadedResponse
            {
                Series = {series}
            };
        }
    }
}