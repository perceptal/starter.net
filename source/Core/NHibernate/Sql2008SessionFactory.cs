using System;
using Core.Config;
using Core.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Core.Persistence.Implementation
{
    public class Sql2005SessionFactory
    {
        public ISessionFactory Build<T>(string application, DefaultAutomappingConfiguration config)
        {
            string script;

            var factory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(application)))

                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<T>(config)
                                    .UseOverridesFromAssemblyOf<T>()
                                    .IgnoreBase<Entity>()
                                    .Conventions.Setup(c =>
                                        {
                                            c.Add<PrimaryKeyConvention>();
                                            c.Add<CustomForeignKeyConvention>();
                                            c.Add<DefaultStringLengthConvention>();
                                        })))

                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(s => script = s, true))

                .BuildSessionFactory();

            return factory;
        }
    }
}
