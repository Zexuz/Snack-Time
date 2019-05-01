using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SnackTime.WebApi
{
    public class WebSocketManager
    {
        private readonly ILogger<WebSocketManager>            _logger;
        private readonly Dictionary<string, IList<WebSocket>> _connections;

        public WebSocketManager(ILogger<WebSocketManager> logger)
        {
            _logger = logger;
            _connections = new Dictionary<string, IList<WebSocket>>();
        }

        public async Task HandleConnect(HttpContext context)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            var connectionId = context.Connection.Id;
            if (!_connections.ContainsKey(connectionId))
            {
                _connections[connectionId] = new List<WebSocket>();
            }

            _connections[connectionId].Add(webSocket);

            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    //How to handle dissconnects 
                    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-2.2#handle-client-disconnects
                    //Have the client make a ping request every x sec, if we have not received a ping in x*2, close and remove the socket connection
                    var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
                    await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                }
                catch (Exception e)
                {
                    _logger.LogDebug(e, "Received error reading from websocket");
                    break;
                }
            }
        }

        public void HandleDisconnect()
        {
        }

        public IList<WebSocket> GetWebSocketsForConnection(string connectionId)
        {
            return _connections.ContainsKey(connectionId) ? _connections[connectionId] : new List<WebSocket>();
        }

        public IList<WebSocket> GetAllWebSockets()
        {
            return _connections.Values.SelectMany(list => list).ToList();
        }
    }

    public interface INotify
    {
        Task SendToAll(string message);
        Task SendToCurrentUser(string message);
    }

    public class WebSocketNotify : INotify
    {
        private readonly ILogger<WebSocketNotify> _logger;
        private readonly WebSocketManager         _webSocketManager;
        private readonly IHttpContextAccessor     _httpContext;

        public WebSocketNotify(ILogger<WebSocketNotify> logger, WebSocketManager webSocketManager, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _webSocketManager = webSocketManager;
            _httpContext = httpContext;
        }

        public async Task SendToAll(string message)
        {
            foreach (var webSocket in _webSocketManager.GetAllWebSockets())
            {
                await SendMessageToWebsocket(webSocket, message);
            }
        }


        public async Task SendToCurrentUser(string message)
        {
            var webSockets = _webSocketManager.GetWebSocketsForConnection(_httpContext.HttpContext.Connection.Id);

            foreach (var webSocket in webSockets)
            {
                await SendMessageToWebsocket(webSocket, message);
            }
        }

        private async Task SendMessageToWebsocket(WebSocket webSocket, string message)
        {
            if (webSocket == null || webSocket.State != WebSocketState.Open)
            {
                _logger.LogWarning($"Websocket is null or not open, msg: {message}");
                return;
            }

            try
            {
                var byteStr = Encoding.UTF8.GetBytes(message);
                await webSocket.SendAsync(byteStr, WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Failed to send websocket message");
            }
        }
    }
}