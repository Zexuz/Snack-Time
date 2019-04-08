using System.Collections.Generic;
using System.Threading.Tasks;
using SonarrSharp;

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
}