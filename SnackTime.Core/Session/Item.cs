namespace SnackTime.Core.Session
{
    public class Item
    {
        public int                                         FileId   { get; set; }
        public MediaServer.Models.ProtoGenerated.Providers Provider { get; set; }
        public string                                      Path     { get; set; }
    }
}