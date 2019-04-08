using System;

namespace SnackTime.Core.Media
{
    public class MediaFile
    {
        public MediaId Id { get; set; }

        public string Path { get; set; }
        public string Name { get; set; }

        public DateTimeOffset LastWatched { get; set; }
        public TimeSpan       TimeWatched { get; set; }
        public DateTimeOffset Downloaded  { get; set; }
    }
}