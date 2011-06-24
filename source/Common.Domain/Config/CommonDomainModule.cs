using System;
using Autofac;
using Common.Domain;
using Common.Domain.Implementation;
using Core.Config;
using Core.Persistence.Implementation;
using NHibernate;

namespace Common.Domain.Config
{
    public class CommonDomainModule : DomainModule<Member>
    {
        public CommonDomainModule(string application)
            : base(application, new CommonNHibernateConfiguration())
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterProviders(builder);

            base.Load(builder);
        }

        private static void RegisterProviders(ContainerBuilder builder)
        {
            builder.RegisterType<FormsAuthenticationHashProvider>().As<IHashProvider>();
            builder.RegisterType<CryptoSaltProvider>().As<ISaltProvider>();
            builder.RegisterType<AuthenticationPolicyProvider>().As<IAuthenticationPolicyProvider>();
        }
    }
}
