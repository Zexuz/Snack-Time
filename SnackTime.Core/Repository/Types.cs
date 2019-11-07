using System.Collections.Generic;

namespace SnackTime.Core.Repository
{
    internal class Episode
    {
//        public DateTimeOffset LastWatched { get; set; }
        public string          Title               { get; set; }
        public int             SeasonNr            { get; set; }
        public int             EpisodeNr           { get; set; }
        public bool            HasWatchedToFinnish { get; set; }
        public List<MediaFile> Type                { get; set; }
    }
}