using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackTime.Core.Media.Series.proto.gen;
using SonarrSharp;
using SonarrSharp.Enum;

namespace SnackTime.Core.Media.Series
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

        public async Task<List<proto.gen.Series>> GetSeries()
        {
            var series = await _client.Series.GetSeries(true);
            return _seriesBuilder.Build(series);
        }

        public async Task<proto.gen.Series> GetSeriesById(int id)
        {
            var series = await _client.Series.GetSeries(id);
            return _seriesBuilder.Build(series);
        }
    }

    public class SeriesBuilder
    {
        public List<proto.gen.Series> Build(IEnumerable<SonarrSharp.Models.Series> series)
        {
            return series.Select(Build).ToList();
        }

        public proto.gen.Series Build(SonarrSharp.Models.Series series)
        {
            return new proto.gen.Series
            {
                Id = series.Id,
                Title = series.Title,
                ImagesUrl = new ImagesUrl
                {
                    Banner = series.Images.SingleOrDefault(image => image.CoverType == CoverType.Banner)?.Url,
                    Poster = series.Images.SingleOrDefault(image => image.CoverType == CoverType.Poster)?.Url,
                    Fanart = series.Images.SingleOrDefault(image => image.CoverType == CoverType.FanArt)?.Url,
                },
                Overview = series.Overview,
                Monitored = series.Monitored,
            };
        }
    }
}