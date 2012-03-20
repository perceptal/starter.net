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
            mapping.HasManyToMany<User>(role => role.Users)
               .Table("Membership")
               .ParentKeyColumn("UserId")
               .ChildKeyColumn("RoleId")
               .Inverse()
               .AsSet();
            
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
