using System.Collections.Generic;

namespace SnackTime.Core.Repository
{
    public class MediaFileRepo : Repo
    {
        public MediaFileRepo(PathService pathService) : base(pathService)
        {
        }

        internal void Upsert(IEnumerable<MediaFile> mediaFiles)
        {
            using (var db = GetDb())
            {
                var col = db.GetCollection<MediaFile>();

                col.InsertBulk(mediaFiles);
                col.EnsureIndex(x => x.EpisodeId);
            }
        }
    }
}