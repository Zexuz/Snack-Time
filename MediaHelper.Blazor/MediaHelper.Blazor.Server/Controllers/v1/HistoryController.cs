using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaHelper.Backend;
using MediaHelper.Model;
using Microsoft.AspNetCore.Mvc;
using SonarrSharp;
using SonarrSharp.Models;
using Episode = SonarrSharp.Endpoints.Episode.Episode;

namespace MediaHelper.Blazor.Server.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly SonarrClient _client;

        public HistoryController()
        {
            _client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");

        }
        
        [HttpGet("watched/last")]
        public ActionResult<MediaFile> LastWatched()
        {
            var mediaFileService = new MedieFileService();
            return Ok(mediaFileService.GetLastWatched());
        }

        [HttpGet("watched/last/{seriesId}")]
        public ActionResult<MediaFile> LastWatchedEpisode(int seriesId)
        {
            var mediaFileService = new MedieFileService();
            return Ok(mediaFileService.GetLastWatched(seriesId));
        }

        [HttpGet("watched")]
        public async Task<ActionResult<List<MediaFile>>> WatchHistory()
        {
            var mediaFileService = new MedieFileService();
            return Ok(mediaFileService.GetLatestWatched());
        }
        
        [HttpGet("watched/series")]
        public async Task<ActionResult<List<MediaFile>>> LastWatchedSeries()
        {
            var mediaFileService = new MedieFileService();

            var list = new HashSet<int>();
            var s =  mediaFileService.GetLatestWatched();
            foreach (var mediaFile in s)
            {
                var episode = await _client.EpisodeFile.GetEpisodeFile((int) mediaFile.IdFromProvider);
                list.Add((int)episode.SeriesId);
            }

            var series = await EpisodeFiles<Series, Series>(i => _client.Series.GetSeries(i), list);
            
            return Ok(series);
        }

        [HttpGet("downloaded")]
        public async Task<ActionResult<int>> LastDownloaded()
        {

            var series = await _client.Series.GetSeries();

            var episodes =  await EpisodeFiles<EpisodeFile,IList<EpisodeFile>>(i => _client.EpisodeFile.GetEpisodeFiles(i),series.Select(s => (int)s.Id).ToList());

            var idsInOrder = episodes.OrderByDescending(file => file.DateAdded).Select(file => (int)file.SeriesId).Distinct();

            var wds = await EpisodeFiles<Series,Series>(i => _client.Series.GetSeries(i),idsInOrder);

            return Ok(wds);
        }

        private static async Task<List<T>> EpisodeFiles<T,TR>(Func<int,Task<TR>> asd, IEnumerable<int> series)
        {
            var list = new List<T>();
            var tasks = series.Select(asd).ToList();
            await Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                if(task.Result is IEnumerable<object>)
                {
                    list.AddRange((IEnumerable<T>) task.Result);
                }
                else
                {
                    if(task.Result is T variable)
                    {
                        list.Add(variable);
                    }
                }
            }

            return list;
        }
    }
}