using System.Collections.Generic;
using System.Threading.Tasks;
using SnackTime.Core.Media;

namespace SnackTime.Core.Session
{
    public interface ISessionRepo
    {
        Task                                                   UpsertSession(MediaServer.Storage.ProtoGenerated.Session session);
        Task<List<MediaServer.Storage.ProtoGenerated.Session>> GetAll();
        Task<MediaServer.Storage.ProtoGenerated.Session>       GetLastSessionForMedia(MediaId mediaId);
    }

    public interface ILocalSessionRepo : ISessionRepo
    {
    }

    public interface IRemoteSessionRepo : ISessionRepo
    {
    }
}