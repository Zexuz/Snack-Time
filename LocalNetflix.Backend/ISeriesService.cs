using System.Collections.Generic;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.Protobuf.MediaPlayerModels;

namespace LocalNetflix.Backend
{
    public interface ISeriesService
    {
        void NewSeriesInMediaPlayer(Episode episode);
        void NewSeriesInMediaPlayer(PlayingMediaInfo info);
        IEnumerable<Series> GetAll();
    }
}