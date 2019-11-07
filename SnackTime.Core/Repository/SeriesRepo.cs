using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;

namespace SnackTime.Core.Repository
{
    internal class Series
    {
//        public DateTimeOffset LastWatched { get; set; }

        public string        ImageUrl { get; set; }
        public string        Title    { get; set; }

        [DbRef]
        public List<Episode> Episodes     { get; set; }
    }

    internal class Episode
    {
//        public DateTimeOffset LastWatched { get; set; }
        public string          Title               { get; set; }
        public int             SeasonNr            { get; set; }
        public int             EpisodeNr           { get; set; }
        public bool            HasWatchedToFinnish { get; set; }
        public List<MediaFile> Type                { get; set; }
    }

    internal class MediaFile
    {
//        public ProviderId     providerId  { get; set; }
        public DateTimeOffset LastWatched { get; set; }
        public TimeSpan       Length      { get; set; }
        public TimeSpan       StartAt     { get; set; }
        public bool           IsFinished  { get; set; }
        public string         Quality     { get; set; }
        public string         Path        { get; set; }
        public DateTimeOffset Added       { get; set; }
        public int            SizeInMB    { get; set; }
    }

    internal class ProviderId
    {
        public Provider Provider { get; }
        public int      Id       { get; }

        public ProviderId(Provider provider, int id)
        {
            Provider = provider;
            Id = id;
        }

        public static bool TryParse(string id, out ProviderId providerId)
        {
            providerId = null;

            var parts = id.Split("-");
            if (parts.Length != 2)
            {
                return false;
            }

            if (!Enum.TryParse(parts[0], out Provider provider))
            {
                return false;
            }

            if (!int.TryParse(parts[1], out var number))
            {
                return false;
            }

            providerId = new ProviderId(provider, number);
            return true;
        }

        public override string ToString()
        {
            return $"{Provider:G}-{Id}";
        }
    }

    internal enum Provider
    {
        Sonarr,
        Radarr
    }

    public class MediaRepo
    {
        private readonly string _databaseFilePath;

        public MediaRepo()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var snackTimePath = Path.Combine(appData, "SnackTime");
            _databaseFilePath = Path.Combine(snackTimePath, "mediaRepo.db");
        }

        private LiteDatabase GetDb()
        {
            return new LiteDatabase(_databaseFilePath);
        }

        internal void Upsert(List<Series> series)
        {
            using (var db = GetDb())
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Series>();

                col.InsertBulk(series);

                col.EnsureIndex(x => x.Title);
                col.EnsureIndex(x => x.Episodes);
                // Let's create an index in phone numbers (using expression). It's a multikey index
                col.EnsureIndex(x => x.Phones, "$.Phones[*]");
            }
        }
    }
}