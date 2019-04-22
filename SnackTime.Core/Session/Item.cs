using System;

namespace SnackTime.Core.Session
{
    public class Item
    {
        public MediaFileId MediaFileId   { get; set; }
        public string      Path          { get; set; }
        public TimeSpan    StartPosition { get; set; }
    }
}