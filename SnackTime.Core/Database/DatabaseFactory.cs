using System;
using System.IO;
using LiteDB;

namespace SnackTime.Core.Database
{
    public class DatabaseFactory
    {

        public LiteDatabase GetDatabase()
        {
            var connectionString = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Media.db");
            return new LiteDatabase(connectionString);
        }
        
        public LiteRepository GetRepository()
        {
            return new LiteRepository(GetDatabase());
        }
    }
}