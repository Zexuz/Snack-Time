using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SnackTime.MediaServer.Runner
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {RequestId:u3} {Method} {Peer}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            var hostBuilder = new HostBuilder()
                .ConfigureServices(service =>
                {
                    service.AddAutofac();
                    service.AddLogging(builder => builder.AddSerilog());
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration(builder => builder.AddEnvironmentVariables("SNACKTIME_"))
                .ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    builder.RegisterModule(new Grpc.DependencyModule(context.Configuration));
                    builder.RegisterModule(new MediaServer.DependencyModule());
                    builder.RegisterModule(new Core.DependencyModule());
                })
                .UseSerilog();


            await hostBuilder.RunConsoleAsync();
        }
    }
}