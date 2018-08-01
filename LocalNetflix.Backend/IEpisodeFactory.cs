using Localnetflix.Backend.Database.Models;
using LocalNetflix.Protobuf.MediaPlayerModels;

namespace LocalNetflix.Backend
{
    public interface IEpisodeFactory
    {
        Episode ParserEpisodeFromMediaInfo(PlayingMediaInfo mediaInfo);
    }
}