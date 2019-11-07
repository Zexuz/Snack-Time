using System.Collections.Generic;

namespace SnackTime.Core.Repository
{
    public class SeriesRepo : Repo
    {
        public SeriesRepo(PathService pathService) : base(pathService)
        {
        }


        internal void Upsert(IEnumerable<Series> series)
        {
            using (var db = GetDb())
            {
                var col = db.GetCollection<Series>();

                col.InsertBulk(series);
                col.EnsureIndex(x => x.Title);
            }
        }

        internal void Upsert(Series series)
        {
            using (var db = GetDb())
            {
                var col = db.GetCollection<Series>();

                col.Insert(series);
                col.EnsureIndex(x => x.Title);
            }
        }
    }
}