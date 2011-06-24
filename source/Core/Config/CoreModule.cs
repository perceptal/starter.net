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
            builder.RegisterType<Repository>().As<IRepository>();
        }
    }
}
