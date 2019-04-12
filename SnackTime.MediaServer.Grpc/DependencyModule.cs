using System;
using Autofac;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SnackTime.MediaServer.Grpc
{
    public class DependencyModule : Module
    {
        private readonly IConfiguration _configuration;

        public DependencyModule(IConfiguration configuration)
        {
            _configuration = configuration;
            VerifySettings(_configuration);
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GrpcHostedService>().As<IHostedService>().SingleInstance();

            var serverPort = new ServerPort(_configuration.GetValue<string>("IP"), _configuration.GetValue<int>("PORT"), ServerCredentials.Insecure);
            builder.RegisterInstance(serverPort).As<ServerPort>();
        }

        private static void VerifySettings(IConfiguration config)
        {
            if (string.IsNullOrWhiteSpace(config["PORT"]))
            {
                Console.WriteLine("PORT environment var need to be set!");
                Environment.Exit(1);
            }

            if (string.IsNullOrWhiteSpace(config["IP"]))
            {
                Console.WriteLine("IP environment var need to be set!");
                Environment.Exit(1);
            }
        }
    }
}