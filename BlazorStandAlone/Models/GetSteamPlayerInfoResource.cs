using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlazorStandAlone.Models
{
    public partial class GetSteamPlayerInfoResource
    {
        [JsonProperty("lastDownloaded")]
        public DateTimeOffset LastDownloaded { get; set; }

        [JsonProperty("lastWatched")]
        public DateTimeOffset LastWatched { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isFromSonarr")]
        public bool IsFromSonarr { get; set; }

        [JsonProperty("seasons")]
        public Dictionary<string, Season> Seasons { get; set; }
    }

    public partial class Season
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("episodes")]
        public Dictionary<string, Episode> Episodes { get; set; }
    }

    public partial class Episode
    {
        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("episodeNumber")]
        public long EpisodeNumber { get; set; }

        [JsonProperty("seasonNumber")]
        public long SeasonNumber { get; set; }

        [JsonProperty("length")]
        public TimeSpan Length { get; set; }

        [JsonProperty("watched")]
        public TimeSpan Watched { get; set; }

        [JsonProperty("lastWatched")]
        public DateTimeOffset LastWatched { get; set; }
    }

    public partial class GetSteamPlayerInfoResource
    {
        public static GetSteamPlayerInfoResource[] FromJson(string json) => JsonConvert.DeserializeObject<GetSteamPlayerInfoResource[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GetSteamPlayerInfoResource[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}