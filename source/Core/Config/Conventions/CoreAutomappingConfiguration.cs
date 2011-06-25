using System;
using Core.Domain;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Core.Config
{
    public class CoreAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace.EndsWith(".Domain") && !type.Name.StartsWith("Core.");
        }

        public override bool IsComponent(Type type)
        {
            return type.IsTypeWithGenericDefinition(typeof(ValueObject<>)) || type.IsValueType;
        }

        public override string GetComponentColumnPrefix(FluentNHibernate.Member member)
        {
            return string.Empty;
        }
    }
}
