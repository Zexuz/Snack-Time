using System;
using System.Collections.Generic;

namespace Localnetflix.Backend.Database.Models
{
    public class Series
    {
        
        public DateTimeOffset LastDownloaded { get; set; }
        public DateTimeOffset LastWatched { get; set; }
        public string Name { get; set; }
        public bool IsFromSonarr { get; set; }
        public List<Season> Seasons { get; set; }
    }

    public class Season
    {
        public int Number { get; set; }
        public List<Episode> Episodes { get; set; }
    }

    public class Episode
    {
        public string Name     { get; set; }
        public int Number { get; set; }
        public TimeSpan Lenght { get; set; }
        public TimeSpan Watched { get; set; }
        public DateTimeOffset LastWatched { get; set; }
    }
}