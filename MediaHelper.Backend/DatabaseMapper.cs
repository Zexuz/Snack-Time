using LiteDB;
using MediaHelper.Model;

namespace MediaHelper.Backend
{
    internal static class DatabaseMapper
    {
        private static bool _hasMapped;

        static DatabaseMapper()
        {
            _hasMapped = false;
        }

        public static void MapEntity()
        {
            if (_hasMapped) return;

            _hasMapped = true;
            var mapper = BsonMapper.Global;

            mapper.Entity<SeriesFile>().Id(series => series.Id, false);
        }
    }
}