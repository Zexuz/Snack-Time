using Localnetflix.Backend.Database.Models;
using LocalNetflix.Protobuf.generated;

namespace LocalNetflix.Backend
{
    public interface IEpisodeFactory
    {
        Episode ParserEpisodeFromMediaInfo(PlayingMediaInfo mediaInfo);
    }
}