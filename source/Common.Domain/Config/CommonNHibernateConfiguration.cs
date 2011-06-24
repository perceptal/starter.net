using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Common.Domain.Config
{
    public class CommonNHibernateConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "Common.Domain";
        }

        public override bool IsComponent(Type type)
        {
            return type == typeof(Password) || type == typeof(Email);
        }

        public override string GetComponentColumnPrefix(FluentNHibernate.Member member)
        {
            return string.Empty;
        }
    }
}
