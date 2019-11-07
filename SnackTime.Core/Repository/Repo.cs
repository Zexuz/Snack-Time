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

        protected LiteDatabase GetDb()
        {
            return new LiteDatabase(_pathService.GetDatabasePath());
        }
    }
}