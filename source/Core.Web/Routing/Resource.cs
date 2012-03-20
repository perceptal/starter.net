using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web.Routing
{
    public class Resource
    {
        private Resource(string name)
        {
            this.Name = name;

            this.Nested = new List<Resource>();
            this.Actions = new List<ResourceAction>();
            this.Exceptions = new List<ResourceMethod>();
        }

        public static Resource Named(string name)
        {
            return new Resource(name);
        }

        protected string Name { get; set; }
        protected string Scope { get; set; }

        protected List<Resource> Nested { get; set; }
        protected List<ResourceAction> Actions { get; set; }
        protected List<ResourceMethod> Exceptions { get; set; }

        protected Resource Parent { get; set; }

        public Resource Scoped(string scope)
        {
            this.Scope = scope;
            return this;
        }

        public Resource Except(params ResourceMethod[] exceptions)
        {
            foreach (var exception in exceptions)
            {
                this.Exceptions.Add(exception);
            }

            return this;
        }

        public Resource Except(params string[] exceptions)
        {
            foreach (var exception in exceptions)
            {
                this.Exceptions.Add(exception.ToEnum<ResourceMethod>());
            }

            return this;
        }

        public Resource Collection(params string[] actions)
        {
            foreach (var action in actions)
            {
                AddAction(action, ResourceMemberType.Collection);
            }

            return this;
        }

        public Resource Member(params string[] actions)
        {
            foreach (var action in actions)
            {
                AddAction(action, ResourceMemberType.Member);
            }

            return this;
        }

        private void AddAction(string action, ResourceMemberType type)
        {
            this.Actions.Add(new ResourceAction
            {
                Action = action,
                Type = type
            });
        }

        public Resource With(params Resource[] resources)
        {
            this.Nested.AddRange(resources);

            foreach(var resource in resources)
            {
                resource.Parent = this;
            }

            return this;
        }

        public static implicit operator ResourceData(Resource builder)
        {
            return Build(builder);
        }

        public static ResourceData Build(Resource builder, bool shallow = false)
        {
            var data = new ResourceData()
            {
                Name = builder.Name,
                Scope = builder.Scope,
                Collection = GetActions(builder, ResourceMemberType.Collection),
                Member = GetActions(builder, ResourceMemberType.Member),
                Except = GetExceptions(builder)
            };

            if (builder.Parent != null)
            {
                data.Parent = Build(builder.Parent, true);
            }

            if (!shallow)
            {
                data.Nested = GetNested(builder);
            }

            return data;
        }

        private static List<ResourceData> GetNested(Resource builder)
        {
            var nested = new List<ResourceData>();
            builder.Nested.ForEach(resource => nested.Add(resource));
            return nested;
        }

        private static List<string> GetActions(Resource builder, ResourceMemberType type)
        {
            var actions = new List<string>();
            builder.Actions.Where(a => a.Type == type).ToList()
                .ForEach(action => actions.Add(action.Action));

            return actions;
        }

        private static List<ResourceMethod> GetExceptions(Resource builder)
        {
            var exceptions = new List<ResourceMethod>();
            builder.Exceptions.ForEach(exception => exceptions.Add(exception));
            return exceptions;
        }
    }
}
