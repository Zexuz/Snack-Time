using System;

namespace MediaHelper.Model
{
    public class MediaFile
    {
        public string          Id             => $"{IdFromProvider}:{Provider}";
        public TimeSpan        Length         { get; set; }
        public TimeSpan        Watched        { get; set; }
        public DateTimeOffset? LastWatched    { get; set; }
        public long            IdFromProvider { get; set; }
        public Provider        Provider       { get; set; }
        public bool            IsCompleted    => Length > TimeSpan.Zero && Length - Watched < TimeSpan.FromMinutes(3);
    }
}