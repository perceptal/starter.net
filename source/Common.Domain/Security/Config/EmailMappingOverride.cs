using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class EmailMappingOverride : IAutoMappingOverride<Email>
    {
        public void Override(AutoMapping<Email> mapping)
        {
            mapping.Map(email => 
                email.Value)
                    .Column("Email")
                    .Access.ReadOnly();
        }
    }
}
