using System;
using System.Threading.Tasks;

namespace LocalNetflix.WebApi
{
    public class WebSocketWrapper : IWebSocketWrapper
    {
        private readonly Func<string, string, Task> _sendAllAsync;

        public WebSocketWrapper(Func<string,string,Task> sendAllAsync)
        {
            _sendAllAsync = sendAllAsync;
        }
        
        public async Task SendAsync(string message, string methodName)
        {
            await _sendAllAsync(message, methodName);
        }
        
    }
}