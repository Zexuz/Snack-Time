using System;
using Autofac;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.WebApi.Hubs;
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
            builder.RegisterType<Repository<Series>>().As<IRepository<Series>>();
        }
    }
}