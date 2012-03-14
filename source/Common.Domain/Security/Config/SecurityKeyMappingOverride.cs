using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class SecurityKeyMappingOverride : IAutoMappingOverride<SecurityKey>
    {
        public void Override(AutoMapping<SecurityKey> mapping)
        {
            mapping.Map(key => key.Low)
                .Column("LowSecurityKey")
                .Access.ReadOnly();

            mapping.Map(key => key.High)
                .Column("HighSecurityKey")
                .Access.ReadOnly();
        }
    }
}
