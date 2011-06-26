using System;
using Autofac;
using Core.Web.Config.Implementation;
using Core.Web.Security;
using Core.Web.Security.Implementation;

namespace Core.Web.Config
{
    public class CoreWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigManager>().As<IConfigManager>();
            builder.RegisterType<SecurityManager>().As<ISecurityManager>();
        }
    }
}
