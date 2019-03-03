using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackTime.Series.ProtoGenerated;
using SonarrSharp;
using SonarrSharp.Enum;

namespace SnackTime.Core.Series
{
    public class SeriesProvider
    {
        private readonly SonarrClient  _client;
        private readonly SeriesBuilder _seriesBuilder;

        public SeriesProvider(SonarrClient client)
        {
            _client = client;
            _seriesBuilder = new SeriesBuilder();
        }

        public async Task<List<SnackTime.Series.ProtoGenerated.Series>> GetSeries()
        {
            var series = await _client.Series.GetSeries(true);
            return _seriesBuilder.Build(series);
        }

        public async Task<SnackTime.Series.ProtoGenerated.Series> GetSeriesById(int id)
        {
            var series = await _client.Series.GetSeries(id);
            return _seriesBuilder.Build(series);
        }
    }

    public class SeriesBuilder
    {
        public List<SnackTime.Series.ProtoGenerated.Series> Build(IEnumerable<SonarrSharp.Models.Series> series)
        {
            return series.Select(Build).ToList();
        }

        public SnackTime.Series.ProtoGenerated.Series Build(SonarrSharp.Models.Series series)
        {
            return new SnackTime.Series.ProtoGenerated.Series
            {
                Id = series.Id,
                Title = series.Title,
                ImagesUrl = new ImagesUrl
                {
                    Banner = series.Images.SingleOrDefault(image => image.CoverType == CoverType.Banner)?.Url,
                    Poster = series.Images.SingleOrDefault(image => image.CoverType == CoverType.Poster)?.Url,
                    Fanart = series.Images.SingleOrDefault(image => image.CoverType == CoverType.FanArt)?.Url,
                }
            };
        }
    }
}