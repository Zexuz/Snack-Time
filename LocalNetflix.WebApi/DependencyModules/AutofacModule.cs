using System;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace LocalNetflix.WebApi.DependencyModules
{
    public class AutofacModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MediaPlayerHub>().As<MediaPlayerHub>();
        }
    }
}