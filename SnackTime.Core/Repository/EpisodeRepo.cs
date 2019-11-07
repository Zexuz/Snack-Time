using System.Collections.Generic;

namespace SnackTime.Core.Repository
{
    public class EpisodeRepo : Repo
    {
        public EpisodeRepo(PathService pathService) : base(pathService)
        {
        }

        internal void Upsert(IEnumerable<Episode> episodes)
        {
            using (var db = GetDb())
            {
                var col = db.GetCollection<Episode>();

                col.InsertBulk(episodes);
                col.EnsureIndex(x => x.SeriesId);
                col.EnsureIndex(x => x.ProviderId);
            }
        }
    }
}