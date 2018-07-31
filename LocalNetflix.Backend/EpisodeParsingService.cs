using System;
using System.Text.RegularExpressions;

namespace LocalNetflix.Backend
{
    public class EpisodeFileParserService : IEpisodeFileParserService
    {
        private const string Pattern = @"(?<name>.*?)\.S?(?<season>\d{1,2})E?(?<episode>\d{2})\.(?<metadata>.*)";


        public EpisodeInfo GetEpisodeInfoFromFileName(string fileName)
        {
            var regEx = new Regex(Pattern, RegexOptions.IgnoreCase);

            var match = regEx.Match(fileName);

            if (!match.Success)
                throw new Exception($"Unable to match with {fileName}");


            return new EpisodeInfo
            {
                Episode = int.Parse(match.Groups["episode"].Value),
                Season = int.Parse(match.Groups["season"].Value),
                Metadata = match.Groups["metadata"].Value,
                Title = FormatTitle(match.Groups["name"].Value)
            };
        }

        private string FormatTitle(string match)
        {
            return match.Replace(".", " ");
        }
    }

    public class EpisodeInfo
    {
        public string Title    { get; set; }
        public int    Season   { get; set; }
        public int    Episode  { get; set; }
        public string Metadata { get; set; }
    }
}