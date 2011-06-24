using System;
using System.Reflection;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Core.Config
{
    public class DefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(128);
        }
    }
}
