using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public interface IIpc
    {
        Task<Response<T>> ExecuteCommand<T>(Request request);
        Task<Response<T>> GetProperty<T>(Property property, params string[] args);
        Task<Response<T>> SetProperty<T>(Property property, params object[] args);
        Task<Response<T>> SetPropertyString<T>(Property property, params string[] args);
        Task<Response<T>> CycleProperty<T>(Property property);
        Request           CreateCommand(IEnumerable<object> command);
        Request           CreateCommand(IEnumerable<object> command, object arg);
        Request           CreateCommand(IEnumerable<object> command, IEnumerable<object> args);
    }
}