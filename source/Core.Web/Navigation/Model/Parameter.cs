using System;
using System.Collections.Generic;
using Core;
using Core.Domain;

namespace Core.Web
{
    public class Parameter : ValueObject<Parameter>
    {
        protected Parameter()
        {
        }

        public Parameter(string name, bool isOptional, string defaultValue)
        {
            Enforce.Argument(() => name, "name");

            this.Name = name;
            this.IsOptional = isOptional;
            this.DefaultValue = defaultValue;
        }

        public string Name { get; private set; }

        public bool IsOptional { get; private set; }

        public string DefaultValue { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return Name;
            yield return IsOptional;
            yield return DefaultValue;
        }
    }
}

