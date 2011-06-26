using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class PasswordMappingOverride : IAutoMappingOverride<Password>
    {
        public void Override(AutoMapping<Password> mapping)
        {
            mapping.Map(password => 
                password.Value)
                    .Column("Password")
                    .Access.ReadOnly();
        }
    }
}
