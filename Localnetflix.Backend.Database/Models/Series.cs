using System;
using System.Collections.Generic;

namespace Localnetflix.Backend.Database.Models
{
    public class Series
    {
        public DateTimeOffset          LastDownloaded { get; set; }
        public DateTimeOffset          LastWatched    { get; set; }
        public string                  Name           { get; set; }
        public bool                    IsFromSonarr   { get; set; }
        public Dictionary<int, Season> Seasons        { get; set; }

        public Series()
        {
            Seasons = new Dictionary<int, Season>();
        }
    }

    public class Season
    {
        public int                      Number   { get; set; }
        public Dictionary<int, Episode> Episodes { get; set; }

        public Season()
        {
            Episodes = new Dictionary<int, Episode>();
        }
    }

    public class Episode
    {
        public string         FileName      { get; set; }
        public string         Name          { get; set; }
        public int            EpisodeNumber { get; set; }
        public int            SeasonNumber  { get; set; }
        public TimeSpan       Length        { get; set; }
        public TimeSpan       Watched       { get; set; }
        public DateTimeOffset LastWatched   { get; set; }
    }
}