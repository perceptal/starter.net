using System;
using Autofac;
using Core.Persistence.Implementation;
using FluentNHibernate.Automapping;
using NHibernate;

namespace Core.Config
{
    public abstract class DomainModule<T> : Module
    {
       public DomainModule(string application, DefaultAutomappingConfiguration config)
        {
            this.Application = application;
            this.AutomappingConfiguration = config;
        }
            
        private DefaultAutomappingConfiguration AutomappingConfiguration { get; set; }

        private string Application { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance<ISessionFactory>(
                new Sql2008SessionFactory().Build<T>(this.Application, this.AutomappingConfiguration));

            builder.RegisterAssemblyTypes(typeof(T).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }    }
}
