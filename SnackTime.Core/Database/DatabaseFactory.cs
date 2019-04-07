using LiteDB;

namespace SnackTime.Core.Database
{
    public class DatabaseFactory
    {
        private const string ConnectionString = "MediaDb";

        public LiteDatabase CreateDatabase()
        {
            return new LiteDatabase(ConnectionString);
        }
    }
}