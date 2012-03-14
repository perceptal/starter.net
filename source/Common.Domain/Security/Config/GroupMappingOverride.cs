using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class GroupMappingOverride : IAutoMappingOverride<Group>
    {
        public void Override(AutoMapping<Group> mapping)
        {
            mapping.HasMany<Group>(g => g.Children)
                .Table("[Group]")
                .Inverse()
                .KeyColumns.Add("ParentId")
                .AsSet();

            mapping.References<Group>(g => g.Parent)
                .Column("ParentId")
                .LazyLoad();

            mapping.HasMany<Person>(g => g.Persons)
                .Table("[Person]")
                .KeyColumns.Add("GroupId")
                .Inverse()
                .AsSet();

            mapping.HasMany<Role>(g => g.Roles)
                .Table("[Role]")
                .KeyColumns.Add("GroupId")
                .Inverse()
                .AsSet();
        }
    }
}
