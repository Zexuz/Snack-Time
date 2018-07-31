using System;
using System.Collections.Generic;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;

namespace LocalNetflix.Backend
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        public void NewSeriesInMediaPlayer(Episode episode)
        {
            episode.LastWatched = DateTimeOffset.Now;

            var series = _seriesRepository.FindByName(episode.Name) ?? CreateSeries(episode);

            if (!series.Seasons.ContainsKey(episode.SeasonNumber))
                series.Seasons.Add(episode.SeasonNumber, new Season {Number = episode.SeasonNumber});

            series.Seasons[episode.SeasonNumber].Episodes[episode.EpisodeNumber] = episode;
            _seriesRepository.InsertOfUpdate(series);
        }

        private Series CreateSeries(Episode episode)
        {
            var series = new Series
            {
                LastWatched = DateTimeOffset.Now,
                Name = episode.Name,
            };
            return series;
        }

        public IEnumerable<Series> GetAll()
        {
            return _seriesRepository.GetAll();
        }
    }
}