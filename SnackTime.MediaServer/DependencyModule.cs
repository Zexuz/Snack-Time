using Autofac;

namespace SnackTime.MediaServer
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeriesController>().As<Service.Series.Series.SeriesBase>();
            builder.RegisterType<EpisodeController>().As<Service.Episode.Episode.EpisodeBase>();
            builder.RegisterType<FileController>().As<Service.File.File.FileBase>();
            builder.RegisterType<SessionController>().As<Service.Session.Session.SessionBase>();


            builder.Register(context =>
            {
                var list = new[]
                {
                    Service.Series.Series.BindService(context.Resolve<Service.Series.Series.SeriesBase>()),
                    Service.Episode.Episode.BindService(context.Resolve<Service.Episode.Episode.EpisodeBase>()),
                    Service.File.File.BindService(context.Resolve<Service.File.File.FileBase>()),
                    Service.Session.Session.BindService(context.Resolve<Service.Session.Session.SessionBase>())
                };

                return list;
            }).AsImplementedInterfaces();
        }
    }
}