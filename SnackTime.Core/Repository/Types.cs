using System;
using System.Collections.Generic;
using System.Net;
using LiteDB;

namespace SnackTime.Core.Repository
{
    public class Image
    {
        public string Url  { get; set; }
        public string Type { get; set; }
    }

    public class Series
    {
        [BsonId]
        public int Id { get; set; }

        public int         ProviderId { get; set; }
        public string      Title      { get; set; }
        public List<Image> Images     { get; set; }
    }

    public class Episode
    {
        [BsonId]
        public int Id { get; set; }

        public int    ProviderId          { get; set; }
        public int    SeriesId            { get; set; }
        public string Title               { get; set; }
        public int    SeasonNr            { get; set; }
        public int    EpisodeNr           { get; set; }
        public bool   HasWatchedToFinnish { get; set; }
    }

    public class MediaFile
    {
        [BsonId]
        public int Id { get; set; }

        public int            ProviderId  { get; set; }
        public int            EpisodeId   { get; set; }
        public DateTimeOffset LastWatched { get; set; }
        public TimeSpan       Length      { get; set; }
        public TimeSpan       StartAt     { get; set; }
        public bool           IsFinished  { get; set; }
        public string         Quality     { get; set; }
        public string         Path        { get; set; }
        public DateTimeOffset Added       { get; set; }
        public int            SizeInMB    { get; set; }
    }
}