namespace SnackTime.Core.Media
{
    public class EpisodeId
    {
        public int SeriesId  { get; set; }
        public int SeasonNr  { get; set; }
        public int EpisodeNr { get; set; }

        public override string ToString()
        {
            return $"{SeriesId}:{SeasonNr}:{EpisodeNr}";
        }

        public static bool TryParse(string id, out EpisodeId episodeId)
        {
            episodeId = new EpisodeId();

            var parts = id.Split(":");

            if (parts.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out var seriesId))
            {
                return false;
            }

            if (!int.TryParse(parts[1], out var seasonNr))
            {
                return false;
            }

            if (!int.TryParse(parts[2], out var episodeNr))
            {
                return false;
            }

            episodeId.SeriesId = seriesId;
            episodeId.SeasonNr = seasonNr;
            episodeId.EpisodeNr = episodeNr;

            return true;
        }
    }
}