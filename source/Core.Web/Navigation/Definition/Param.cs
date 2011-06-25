using System;

namespace Core.Web
{
    public class Param
    {
        private Param(string name)
        {
            this.Name = name;
        }

        protected string Name { get; set; }

        protected bool IsOptional { get; set; }

        protected string DefaultValue { get; set; }

        public static Param Named(string name)
        {
            return new Param(name);
        }

        public static implicit operator Parameter(Param builder)
        {
            return Build(builder);
        }

        public static Parameter Build(Param builder)
        {
            return new Parameter(builder.Name, builder.IsOptional, builder.DefaultValue);
        }

        public Param Optional(string value)
        {
            this.IsOptional = true;
            this.DefaultValue = value;

            return this;
        }
    }
}
