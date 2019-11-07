using LiteDB;

namespace SnackTime.Core.Repository
{
    public abstract class Repo
    {
        private readonly PathService _pathService;

        public Repo(PathService pathService)
        {
            _pathService = pathService;
        }

        public LiteDatabase GetDb()
        {
            return new LiteDatabase(_pathService.GetDatabasePath());
        }
    }
}