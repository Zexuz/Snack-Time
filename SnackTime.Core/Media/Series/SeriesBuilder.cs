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