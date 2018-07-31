using System;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.Protobuf.generated;

namespace LocalNetflix.Backend
{
    public class EpisodeFactory : IEpisodeFactory
    {
        private readonly IEpisodeFileParserService _episodeFileParserService;

        public EpisodeFactory(IEpisodeFileParserService episodeFileParserService)
        {
            _episodeFileParserService = episodeFileParserService;
        }


        public Episode ParserEpisodeFromMediaInfo(PlayingMediaInfo mediaInfo)
        {
            var episodeInfo = _episodeFileParserService.GetEpisodeInfoFromFileName(mediaInfo.FileName);

            return new Episode
            {
                Name = episodeInfo.Title,
                EpisodeNumber = episodeInfo.Episode,
                SeasonNumber = episodeInfo.Season,
                FileName = mediaInfo.FileName,
                Lenght = TimeSpan.FromSeconds(mediaInfo.Duration),
                Watched = TimeSpan.FromSeconds(mediaInfo.Eplipsed),
                LastWatched = DateTimeOffset.MinValue
            };
        }
    }
}