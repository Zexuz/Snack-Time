using System.Threading.Tasks;
using SonarrSharp;

namespace SnackTime.Core.Media.Episodes
{
    public class EpisodeFileLookupProvider
    {
        private readonly SonarrClient _client;

        public EpisodeFileLookupProvider(SonarrClient client)
        {
            _client = client;
        }

        public async Task<Temp> GetFileInfoForId(int id)
        {
            var episodeFile = await _client.EpisodeFile.GetEpisodeFile(id);
            return new Temp
            {
                SeriesId = episodeFile.SeriesId,
                Path = episodeFile.Path,
            }; 
        }
    }

    //TODO Convvert to proto file
    public class Temp
    {
        public string Path { get; set; }
        public int    SeriesId { get; set; }
    }
}