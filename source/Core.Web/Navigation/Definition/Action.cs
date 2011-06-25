using System;

namespace Core.Web
{
    public class Action : Navigation
    {
        protected Action(string name)
            : base(name)
        {
        }

        protected Action(string name, string title)
            : base(name, title)
        {
        }

        protected Action(string name, string title, string description)
            : base(name, title, description)
        {
        }

        public static Action Named(string name)
        {
            return new Action(name);
        }

        public static Action Named(string name, string title)
        {
            return new Action(name, title);
        }

        public static Action Named(string name, string title, string description)
        {
            return new Action(name, title, description);
        }

        public static implicit operator Page(Action builder)
        {
            return Build(builder);
        }

        protected override void SetOptions()
        {
            this.WithOptions(PageOption.Action);
        }

        public Action System()
        {
            this.WithOptions(PageOption.System);

            return this;
        }

        public Action Parameterized()
        {
            return this.WithParameters(Param.Named("id"));
        }

        public Action WithParameters(params Param[] parameters)
        {
            this.WithOptions(PageOption.Action.Set(PageOption.Parameterized).Set(PageOption.Hidden));

            this.Parameters.AddRange(parameters);

            return this;
        }

        public Action ForController(string controller)
        {
            this.ParentOverride = controller;
            return this;
        }

        public Page Build()
        {
            return this;
        }
    }
}
