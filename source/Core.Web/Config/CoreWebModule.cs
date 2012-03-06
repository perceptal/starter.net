using System;
using Autofac;
using Core.Web.Config.Implementation;
using Core.Web.Security;
using Core.Web.Security.Implementation;

namespace Core.Web.Config
{
    public class CoreWebModule : Module
    {
        public CoreWebModule(Page navigation)
        {
            this.Navigation = navigation;
        }

        private Page Navigation { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigManager>().As<IConfigManager>()
                .WithParameter(new NamedParameter("navigation", this.Navigation));

            builder.RegisterType<SecurityManager>().As<ISecurityManager>();
        }
    }
}
