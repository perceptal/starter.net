using System;
using Autofac;
using Core.Persistence;
using Core.Persistence.Implementation;

namespace Core.Config
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}
