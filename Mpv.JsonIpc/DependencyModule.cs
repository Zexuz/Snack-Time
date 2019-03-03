using Autofac;

namespace Mpv.JsonIpc
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NamedPipeFactory>().As<INamedPipeFactory>();
            builder.RegisterType<Manager>().As<IManager>();
            builder.RegisterType<Ipc>().As<IIpc>();
            builder.RegisterType<Api>().As<IApi>();
        }
    }
}