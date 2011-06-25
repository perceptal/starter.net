using System;

namespace Core.Web
{
    public class Controller : Navigation
    {
        private Controller(string name)
            : base(name)
        {
        }

        private Controller(string name, string title)
            : base(name, title)
        {
        }

        private Controller(string name, string title, string description)
            : base(name, title, description)
        {
        }

        public static Controller Named(string name)
        {
            return new Controller(name);
        }

        public static Controller Named(string name, string description)
        {
            return new Controller(name, description);
        }

        public static Controller Named(string name, string title, string description)
        {
            return new Controller(name, title, description);
        }

        public static implicit operator Page(Controller builder)
        {
            return Build(builder);
        }

        protected override void SetOptions()
        {
            this.WithOptions(PageOption.Controller);
        }

        public Page Build()
        {
            return this;
        }
    }
}
