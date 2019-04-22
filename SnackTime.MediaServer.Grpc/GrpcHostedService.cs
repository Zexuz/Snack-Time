using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;

namespace SnackTime.MediaServer.Grpc
{
    public class GrpcHostedService : IHostedService
    {
        private readonly Server _server;

        public GrpcHostedService(ServerPort serverPort, IEnumerable<ServerServiceDefinition> serviceDefinitions)
        {
            var server = new Server
            {
                Ports = {serverPort}
            };

            foreach (var definition in serviceDefinitions)
            {
                server.Services.Add(definition);
            }

            _server = server;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _server.Start();

            foreach (var serverPort in _server.Ports)
            {
                Console.WriteLine($"gRPC Server listening on {serverPort.Host}:{serverPort.Port}");
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken) => await _server.ShutdownAsync();
    }
}