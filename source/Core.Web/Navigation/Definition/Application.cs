using System;

namespace Core.Web
{
    public class Application : Navigation
    {
        private Application(string name)
            : base(name)
        {
        }

        private Application(string name, string title)
            : base(name, title)
        {
        }

        private Application(string name, string title, string description)
            : base(name, title, description)
        {
        }

        public static Application Named(string name)
        {
            return new Application(name);
        }

        public static Application Named(string name, string title)
        {
            return new Application(name, title);
        }

        public static Application Named(string name, string title, string description)
        {
            return new Application(name, title, description);
        }

        public static implicit operator Page(Application builder)
        {
            return Build(builder);
        }

        protected override void SetOptions()
        {
            this.WithOptions(PageOption.NotNavigable.Set(PageOption.Anonymous));
            this.Application = this.Id;
        }

        public Page Build()
        {
            return this;
        }
    }
}

