using System.Threading.Tasks;
using SnackTime.Core.Media.Series;

namespace SnackTime.Core.Media
{
    public class MediaSyncService
    {
        private readonly SeriesProvider _seriesProvider;

        public MediaSyncService(SeriesProvider seriesProvider)
        {
            _seriesProvider = seriesProvider;
        }
        
        
        
        public async Task SyncMediaProviders()
        {
            var series = await _seriesProvider.GetSeries();
            
            
        }
        
    }
}