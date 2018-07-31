using LiteDB;
using Localnetflix.Backend.Database.Models;

namespace Localnetflix.Backend.Database
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

            mapper.Entity<Series>()
                .Id(series => series.Name);

        }
    }
}