using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class PersonMappingOverride : IAutoMappingOverride<Person>
    {
        public void Override(AutoMapping<Person> mapping)
        {
            mapping.References<Group>(p => p.Group);

            mapping.Map(p => p.LeftOn);
            mapping.Map(p => p.Dob);
            mapping.Map(p => p.Gender).CustomType(typeof(Gender));
            mapping.Map(p => p.MaritalStatus).CustomType(typeof(Marital));

            mapping.HasManyToMany<Role>(p => p.Roles)
                .Table("Membership")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("PersonId")
                .AsSet();

            mapping.HasMany<Photo>(p => p.Photos)
                .Table("Photo")
                .KeyColumns.Add("PersonId")
                .AsSet();

            mapping.HasMany<Account>(p => p.Accounts)
                .Table("[Account]")
                .Component(c =>
                    {
                        c.Map(account => account.Identity).Column("[Identity]");
                        c.Map(account => account.Site).CustomType(typeof(Site));
                    })
                .KeyColumns.Add("PersonId")
                .AsSet();
        }
    }
}
