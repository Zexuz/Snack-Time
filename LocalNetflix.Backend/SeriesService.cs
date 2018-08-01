using System;
using System.Collections.Generic;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.Protobuf.MediaPlayerModels;
using LocalNetflix.WebApi;
using Newtonsoft.Json;

namespace LocalNetflix.Backend
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IEpisodeFactory   _episodeFactory;
        private readonly IWebSocketWrapper _webSocketWrapper;

        public SeriesService(ISeriesRepository seriesRepository, IEpisodeFactory episodeFactory, IWebSocketWrapper webSocketWrapper)
        {
            _seriesRepository = seriesRepository;
            _episodeFactory = episodeFactory;
            _webSocketWrapper = webSocketWrapper;
        }

        public void NewSeriesInMediaPlayer(PlayingMediaInfo info)
        {
            var episode = _episodeFactory.ParserEpisodeFromMediaInfo(info);
            NewSeriesInMediaPlayer(episode);
        }

        public void NewSeriesInMediaPlayer(Episode episode)
        {
            episode.LastWatched = DateTimeOffset.Now;

            var series = _seriesRepository.FindByName(episode.Name) ?? CreateSeries(episode);

            if (!series.Seasons.ContainsKey(episode.SeasonNumber))
                series.Seasons.Add(episode.SeasonNumber, new Season {Number = episode.SeasonNumber});

            series.Seasons[episode.SeasonNumber].Episodes[episode.EpisodeNumber] = episode;
            _seriesRepository.InsertOfUpdate(series);

            _webSocketWrapper.SendAsync(JsonConvert.SerializeObject(episode),"Receive");
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