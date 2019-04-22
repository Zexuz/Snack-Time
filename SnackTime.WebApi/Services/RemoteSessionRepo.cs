using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackTime.Core;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Service.Session;

namespace SnackTime.WebApi.Services
{
    public class RemoteSessionRepo : IRemoteSessionRepo
    {
        private readonly Session.SessionClient _sessionClient;

        public RemoteSessionRepo(GrpcClientProvider clientProvider)
        {
            _sessionClient = clientProvider.GetSessionClient();
        }

        public async Task UpsertSession(MediaServer.Storage.ProtoGenerated.Session session)
        {
            await _sessionClient.UpsertAsync(new UpsertRequest
            {
                Session = session
            });
        }

        public async Task<List<MediaServer.Storage.ProtoGenerated.Session>> GetAll()
        {
            var res = await _sessionClient.GetAllAsync(new GetAllRequest());
            return res.Sessions.ToList();
        }
    }
}