namespace LocalNetflix.Backend
{
    public interface IEpisodeFileParserService
    {
        EpisodeInfo GetEpisodeInfoFromFileName(string fileName);
    }
}