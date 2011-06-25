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
    public class Sql2008SessionFactory
    {
        public ISessionFactory Build<T>(string application, DefaultAutomappingConfiguration config)
        {
            string[] scripts = null;

            var factory = Fluently.Configure()

                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromConnectionStringWithKey(application)))

                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<T>(config)
                                    .UseOverridesFromAssemblyOf<T>()
                                    .IgnoreBase<Entity>()
                                    .Conventions.Setup(c =>
                                        {
                                            c.Add<PrimaryKeyConvention>();
                                            c.Add<CustomForeignKeyConvention>();
                                            c.Add<DefaultStringLengthConvention>();
                                        })))

                .ExposeConfiguration(c =>
                {
                    new SchemaUpdate(c).Execute(true, true);
                    //scripts = c.GenerateSchemaUpdateScript(new NHibernate.Dialect.MsSql2005Dialect(), new DatabaseMetadata();
                })

                .BuildSessionFactory();

            return factory;
        }
    }
}
