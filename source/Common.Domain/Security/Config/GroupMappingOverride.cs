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
            mapping.Map(g => g.Level).CustomType(typeof(GroupLevel));

            mapping.Component<Email>(group => group.Email, email =>
            {
                email.Map(e => e.Value).Column("Email");
            });

            mapping.Component<Contact>(group => group.Contact, contact =>
            {
                contact.Map(c => c.Number).Column("Contact");
            });

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
