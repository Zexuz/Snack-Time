using System;
using SonarrSharp.Models;

namespace MediaHelper.Model
{
    public class FileExploror
    {
        public string[] Files { get; set; }
        public string[] Dirs  { get; set; }
    }
    
    public class ContinueWatchingResponse
    {
        public Episode                Episode      { get; set; }
        public TimeSpan               WhereToStart { get; set; }
        public ContinueWatchingStatus Status       { get; set; }
    }
    public enum ContinueWatchingStatus {
        InProgress,
        NextEpisode,
        NewSeries,
        NoNewEpisodes
    }
}