using System;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;

namespace Core.Config
{
    public class EnumConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum)
                .Expect(x => x.Length == 0);
        }
        
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(Enum.GetNames(instance.Property.PropertyType).Max(name => name.Length));
            instance.CustomType(typeof(string));
        }

    }
}
