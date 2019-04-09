using System.Collections.Generic;
using System.Linq;
using SnackTime.Core.Media.Series.proto.gen;
using SonarrSharp.Enum;

namespace SnackTime.Core.Media.Series
{
    public class SeriesBuilder
    {
        public List<proto.gen.Series> Build(IEnumerable<SonarrSharp.Models.Series> series)
        {
            return series.Select(Build).ToList();
        }

        public proto.gen.Series Build(SonarrSharp.Models.Series series)
        {
            return BuildInternal(series);
        }

        public List<proto.gen.Series> Build(IEnumerable<SonarrSharp.Models.Record> records)
        {
            return records.Select(Build).ToList();
        }

        public proto.gen.Series Build(SonarrSharp.Models.Record record)
        {
            return BuildInternal(record.Series);
        }

        private proto.gen.Series BuildInternal(SonarrSharp.Models.Series series)
        {
            return new proto.gen.Series
            {
                Id = series.Id,
                Title = series.Title,
                ImagesUrl = new ImagesUrl
                {
                    Banner = $"/MediaCover/{series.Id}/banner.jpg",
                    Poster = $"/MediaCover/{series.Id}/poster.jpg",
                    Fanart = $"/MediaCover/{series.Id}/fanart.jpg",
                },
                Overview = series.Overview,
                Monitored = series.Monitored,
            };
        }
    }
}