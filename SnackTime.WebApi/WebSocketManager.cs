using System.Collections.Generic;
using System.Net.WebSockets;

namespace SnackTime.WebApi
{
    public class WebSocketManager
    {
        private readonly Dictionary<string, WebSocket> _webSockets;

        public WebSocketManager()
        {
            _webSockets = new Dictionary<string, WebSocket>();
        }

        public void HandleConnect()
        {
            
        }

        public void HandleDisconnect()
        {
            
        }

        public INotify GetClint(string clientKey)
        {
            _webSockets["0"].
            return _webSockets[clientKey];
        }

    }

    public interface INotify
    {
        void Send(string message);
    }

    public class WebsocketNotify : INotify
    {
        public void Send(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}