using System.Threading.Tasks;

namespace LocalNetflix.WebApi
{
    public interface IWebSocketWrapper
    {
        Task SendAsync(string message, string methodName);
    }
}