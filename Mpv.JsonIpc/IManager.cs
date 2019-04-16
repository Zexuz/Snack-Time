using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public interface IManager
    {
        Task<Response<T>> Execute<T>(Request request);
        void              Dispose();
    }
}