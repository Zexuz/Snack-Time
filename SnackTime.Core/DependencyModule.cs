using Autofac;
using SonarrSharp;

namespace SnackTime.Core
{
    public class DependencyModule : Module
    {
        private readonly SonarrConfig _sonarrConfig;

        public DependencyModule(SonarrConfig sonarrConfig)
        {
            _sonarrConfig = sonarrConfig;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var sonarrClient = new SonarrClient(_sonarrConfig.Host, _sonarrConfig.Port, _sonarrConfig.ApiKey);
            builder.RegisterInstance(sonarrClient).As<SonarrClient>();
        }

        public class SonarrConfig
        {
            public string Host   { get; set; }
            public int    Port   { get; set; }
            public string ApiKey { get; set; }
        }
    }
}