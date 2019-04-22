using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SonarrSharp;

namespace SnackTime.Core.Media.Series
{
    public class SeriesProvider
    {
        private readonly SonarrClient  _client;
        private readonly SeriesBuilder _seriesBuilder;

        public SeriesProvider(SonarrFactory sonarrFactory)
        {
            _client = sonarrFactory.GetClient();
            _seriesBuilder = new SeriesBuilder();
        }

        public async Task<List<MediaServer.Models.ProtoGenerated.Series>> GetLatest()
        {
            var records = new Dictionary<int, SonarrSharp.Models.Record>();
            int page = 1;
            while (records.Count < 18)
            {
                var history = await _client.History.GetHistory("date", pageSize: 10, page: page);

                var downloaded = history.Records.Where(r => r.EventType == "downloadFolderImported");
                var distinct = downloaded.GroupBy(r => r.Series.Id).SelectMany(r => r.Take(1));

                foreach (var record in distinct)
                {
                    if (records.ContainsKey(record.Series.Id)) continue;
                    records[record.Series.Id] = record;
                }

                page++;

                if (history.Page * history.PageSize >= history.TotalRecords)
                    break;
            }

            return _seriesBuilder.Build(records.Select(pair => pair.Value));
        }

        public async Task<List<MediaServer.Models.ProtoGenerated.Series>> GetSeries()
        {
            var series = await _client.Series.GetSeries(true);
            return _seriesBuilder.Build(series);
        }

        public async Task<MediaServer.Models.ProtoGenerated.Series> GetSeriesById(int id)
        {
            var series = await _client.Series.GetSeries(id);
            return _seriesBuilder.Build(series);
        }
    }
}