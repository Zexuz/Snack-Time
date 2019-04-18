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
        }
    }
}