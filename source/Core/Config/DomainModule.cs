﻿using System;
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
                new Sql2005SessionFactory().Build<T>(this.Application, this.AutomappingConfiguration))
                    .SingleInstance();

            builder.RegisterType<TransactionTracker>()
                .InstancePerLifetimeScope();

            builder
                .Register(c => c.Resolve<ISessionFactory>().OpenSession())
                    .As<ISession>()
                    .InstancePerLifetimeScope()
                    .OnActivated(session =>
                        session.Context.Resolve<TransactionTracker>()
                            .SetActive(((ISession)session.Instance).BeginTransaction()));

            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(T).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }    
    }
}
