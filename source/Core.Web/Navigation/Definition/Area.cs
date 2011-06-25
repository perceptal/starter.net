using System;

namespace Core.Web
{
    public class Area : Navigation
    {
        private Area(string name)
            : base(name)
        {
        }

        private Area(string name, string title)
            : base(name, title)
        {
        }

        private Area(string name, string title, string description)
            : base(name, title, description)
        {
        }

        public static Area Named(string name)
        {
            return new Area(name);
        }

        public static Area Named(string name, string title)
        {
            return new Area(name, title);
        }

        public static Area Named(string name, string title, string description)
        {
            return new Area(name, title, description);
        }

        public static implicit operator Page(Area builder)
        {
            return Build(builder);
        }

        protected override void SetOptions()
        {
        }

        public Page Build()
        {
            return this;
        }
    }
}
