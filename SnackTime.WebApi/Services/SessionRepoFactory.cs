using System.Threading.Tasks;
using SnackTime.Core.Session;

namespace SnackTime.WebApi.Services
{
    public class SessionRepoFactory : ISessionRepoFactory
    {
        private readonly ILocalSessionRepo  _localSessionRepo;
        private readonly IRemoteSessionRepo _remoteSessionRepo;
        private readonly StatusService _statusService;

        public SessionRepoFactory(ILocalSessionRepo localSessionRepo, IRemoteSessionRepo remoteSessionRepo, StatusService statusService)
        {
            _localSessionRepo = localSessionRepo;
            _remoteSessionRepo = remoteSessionRepo;
            _statusService = statusService;
        }
        
        public async Task<ISessionRepo> GetRepo()
        {
            if (await _statusService.IsOnline())
            {
                return _remoteSessionRepo;
            }

            return _localSessionRepo;
        }
    }
}