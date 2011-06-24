using System;
using Core.Config;
using Core.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Core.Persistence.Implementation
{
    public class Sql2008SessionFactory
    {
        public ISessionFactory Build<T>(string application, DefaultAutomappingConfiguration config)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(application)))
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<T>(config)
                                    .IgnoreBase<Entity>()
                                    .Conventions.Setup(c => c.Add<PrimaryKeyConvention>())))

                .BuildSessionFactory();
        }
    }
}
