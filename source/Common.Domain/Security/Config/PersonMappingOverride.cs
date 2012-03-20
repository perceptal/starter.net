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
            mapping.IgnoreProperty(p => p.FullName);

            mapping.References<Group>(p => p.Group);

            mapping.Map(p => p.LeftOn);
            mapping.Map(p => p.Dob);
            mapping.Map(p => p.Gender).CustomType(typeof(Gender));
            mapping.Map(p => p.MaritalStatus).CustomType(typeof(Marital));

            mapping.Component<Email>(group => group.Email, email =>
            {
                email.Map(e => e.Value).Column("Email");
            });

            mapping.HasMany<Photo>(p => p.Photos)
                .Table("Photo")
                .KeyColumns.Add("PersonId")
                .Inverse()
                .Cascade.All()
                .AsSet();

            mapping.HasMany<Account>(p => p.Accounts)
                .Table("[Account]")
                .Component(c =>
                {
                    c.Map(account => account.Identity).Column("[Identity]");
                    c.Map(account => account.Site).CustomType(typeof(Site));
                })
                .KeyColumns.Add("PersonId")
                .Cascade.All()
                .AsSet();

            mapping.HasMany<Contact>(p => p.Contacts)
                .Table("[Contact]")
                .Component(c =>
                {
                    c.Map(contact => contact.Number).Column("[Number]");
                    c.Map(contact => contact.Type).CustomType(typeof(ContactType));
                })
                .KeyColumns.Add("PersonId")
                .Cascade.All()
                .AsSet();
        }
    }
}
