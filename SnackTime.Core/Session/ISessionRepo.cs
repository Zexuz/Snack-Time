using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnackTime.Core.Session
{
    public interface ISessionRepo
    {
        Task                                                   UpsertSession(MediaServer.Storage.ProtoGenerated.Session session);
        Task<List<MediaServer.Storage.ProtoGenerated.Session>> GetAll();
    }

    public interface ILocalSessionRepo : ISessionRepo
    {
    }

    public interface IRemoteSessionRepo : ISessionRepo
    {
    }
}