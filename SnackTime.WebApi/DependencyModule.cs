using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using SnackTime.Core;
using SnackTime.Core.Session;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GrpcClientProvider>().AsSelf().SingleInstance();
            builder.RegisterType<MediaPlayerObserver>().As<IHostedService>().SingleInstance();

            builder.RegisterType<FileService>().AsSelf();
            builder.RegisterType<StatusService>().AsSelf();
            builder.RegisterType<SessionSyncService>().AsSelf();
            builder.RegisterType<FileDownloadService>().AsSelf();

            builder.RegisterType<RemoteSessionRepo>().As<IRemoteSessionRepo>();
            builder.RegisterType<SessionRepoFactory>().As<ISessionRepoFactory>();

            builder.RegisterType<WebSocketNotify>().As<INotify>();
            builder.RegisterType<WebSocketManager>().AsSelf().SingleInstance();
            
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}