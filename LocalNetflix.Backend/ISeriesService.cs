using System.Collections.Generic;
using Localnetflix.Backend.Database.Models;

namespace LocalNetflix.Backend
{
    public interface ISeriesService
    {
        void NewSeriesInMediaPlayer(Episode episode);
        IEnumerable<Series> GetAll();
    }
}