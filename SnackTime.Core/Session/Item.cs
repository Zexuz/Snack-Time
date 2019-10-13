using System;
using SnackTime.Core.Media;

namespace SnackTime.Core.Session
{
    public class Item
    {
        public PlayableId PlayableId    { get; set; }
        public MediaId    MediaId       { get; set; }
        public string     Path          { get; set; }
        public TimeSpan   StartPosition { get; set; }
    }
}