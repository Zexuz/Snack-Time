namespace MediaHelper.Model
{
    public class SeriesFile : MediaFile
    {
        public new Provider Provider => Provider.Sonarr;
        public     long     SeriesId { get; set; }
    }
}