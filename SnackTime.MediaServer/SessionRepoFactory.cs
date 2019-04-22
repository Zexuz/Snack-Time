using System.Threading.Tasks;
using SnackTime.Core.Session;

namespace SnackTime.MediaServer
{
    public class SessionRepoFactory : ISessionRepoFactory
    {
        private readonly ILocalSessionRepo _localSessionRepo;

        public SessionRepoFactory(ILocalSessionRepo localSessionRepo)
        {
            _localSessionRepo = localSessionRepo;
        }

        public Task<ISessionRepo> GetRepo()
        {
            return Task.FromResult<ISessionRepo>(_localSessionRepo);
        }
    }
}