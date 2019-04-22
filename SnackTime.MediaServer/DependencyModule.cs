using Autofac;
using SnackTime.Core;
using SnackTime.Core.Media.Series;
using SnackTime.Core.Session;

namespace SnackTime.MediaServer
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeriesProvider>().AsSelf();

            builder.RegisterType<LocalSessionRepo>().As<ILocalSessionRepo>();
            builder.RegisterType<LocalSessionRepo>().As<IRemoteSessionRepo>();

            builder.RegisterType<SessionRepoFactory>().As<ISessionRepoFactory>();

            builder.RegisterType<SeriesController>().As<Service.Series.Series.SeriesBase>();
            builder.RegisterType<EpisodeController>().As<Service.Episode.Episode.EpisodeBase>();
            builder.RegisterType<FileController>().As<Service.File.File.FileBase>();
            builder.RegisterType<SessionController>().As<Service.Session.Session.SessionBase>();
            builder.RegisterType<StatusController>().As<Service.Status.Status.StatusBase>();


            builder.Register(context =>
            {
                var list = new[]
                {
                    Service.Series.Series.BindService(context.Resolve<Service.Series.Series.SeriesBase>()),
                    Service.Episode.Episode.BindService(context.Resolve<Service.Episode.Episode.EpisodeBase>()),
                    Service.File.File.BindService(context.Resolve<Service.File.File.FileBase>()),
                    Service.Session.Session.BindService(context.Resolve<Service.Session.Session.SessionBase>()),
                    Service.Status.Status.BindService(context.Resolve<Service.Status.Status.StatusBase>())
                };

                return list;
            }).AsImplementedInterfaces();
        }
    }
}