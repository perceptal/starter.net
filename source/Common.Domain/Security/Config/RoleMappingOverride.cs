using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class RoleMappingOverride : IAutoMappingOverride<Role>
    {
        public void Override(AutoMapping<Role> mapping)
        {
            mapping.HasMany<Claim>(role => role.Claims)
                .Table("[Claim]")
                .Component(c =>
                    {
                        c.Map(claim => claim.Securable);
                        c.Map(claim => claim.Right).CustomType(typeof(Right)).Column("[Right]");
                    })
                 .KeyColumns.Add("RoleId")
                 .AsSet();
        }
    }
}
