using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class UserMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Map(u => u.LastSignOnAt);
            mapping.Map(u => u.IsLocked);
            mapping.Map(u => u.ForcePasswordChange);
            mapping.Map(u => u.IsSupport);
        }
    }
}
