using System.Threading.Tasks;

namespace SnackTime.Core.Session
{
    public interface ISessionRepoFactory
    {
        Task<ISessionRepo> GetRepo();
    }

   
}