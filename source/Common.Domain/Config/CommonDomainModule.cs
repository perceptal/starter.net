using System;
using Autofac;
using Common.Domain;
using Common.Domain.Implementation;
using Core.Config;
using Core.Persistence.Implementation;
using NHibernate;

namespace Common.Domain.Config
{
    public class CommonDomainModule : DomainModule<User>
    {
        public CommonDomainModule(string application)
            : base(application, new CommonAutomappingConfiguration())
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterProviders(builder);
            RegisterServices(builder);

            base.Load(builder);
        }

        private static void RegisterProviders(ContainerBuilder builder)
        {
            builder.RegisterType<FormsAuthenticationHashProvider>().As<IHashProvider>();
            builder.RegisterType<CryptoSaltProvider>().As<ISaltProvider>();
            builder.RegisterType<AuthenticationPolicyProvider>().As<IAuthenticationPolicyProvider>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(User).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
