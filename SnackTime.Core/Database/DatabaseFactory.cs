using LiteDB;

namespace SnackTime.Core.Database
{
    public class DatabaseFactory
    {
        private const string ConnectionString = "MediaDb";

        public LiteDatabase GetDatabase()
        {
            return new LiteDatabase(ConnectionString);
        }
        
        public LiteRepository GetRepository()
        {
            return new LiteRepository(GetDatabase());
        }
    }
}