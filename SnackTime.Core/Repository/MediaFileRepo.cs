using System.Collections.Generic;
using System.Threading.Tasks;
using SonarrSharp.Models;

namespace SnackTime.Core.Repository
{
    public class MediaFileRepo : Repo
    {
        public MediaFileRepo(PathService pathService) : base(pathService)
        {
        }

        internal void Upsert(MediaFile mediaFiles)
        {
            using (var db = GetDb())
            {
                var col = db.GetCollection<MediaFile>();

                col.Insert(mediaFiles);
                col.EnsureIndex(x => x.EpisodeId);
            }
        }
    }
}