using System;
using System.Collections.Generic;
using Common.Domain;

namespace Core.Web
{
    public abstract class Navigation
    {
        protected Navigation(string name)
            : this(name, name.ToHumanName())
        {
        }

        protected Navigation(string name, string title)
            : this(name, title, string.Empty)
        {
        }

        protected Navigation(string name, string title, string description)
        {
            this.Override = this.Name = name;
            this.Title = title;
            this.Description = description;
            this.Index = 0;
            this.Children = new List<Navigation>();
            this.Parameters = new List<Param>();
            this.Claims = new List<ClaimBase>();
            this.Options = PageOption.None;

            this.SetOptions();
        }

        protected string Name { get; set; }

        protected string Title { get; set; }

        protected string Description { get; set; }

        protected string Override { get; set; }

        protected string ParentOverride { get; set; }

        protected string Application { get; set; }

        protected string Classifier { get; set; }

        protected string Condition { get; set; }

        protected string Icon { get; set; }

        protected int Index { get; set; }

        protected PageOption Options { get; set; }

        protected Navigation Parent { get; set; }

        protected List<Navigation> Children { get; set; }

        protected List<Param> Parameters { get; set; }

        protected List<ClaimBase> Claims { get; set; }

        protected string LegacyUrl { get; set; }

        public static implicit operator Page(Navigation builder)
        {
            return Build(builder);
        }

        protected static Page Build(Navigation builder)
        {
            var parameters = new List<Parameter>();
            builder.Parameters.ForEach(param => parameters.Add(param));

            var claims = new List<Claim>();
            builder.Claims.ForEach(claim => claims.Add(claim));

            int index = 0;
            var children = new List<Page>();
            builder.Children.ForEach(child =>
            {
                child.Index = index++;
                children.Add(child);
            });

            var built = new Page
            {
                Name = GetName(builder, builder.Name),
                Title = builder.Title,
                Override = builder.Override,
                ParentOverride = builder.ParentOverride,
                Description = builder.Description,
                Application = GetApplication(builder),
                Index = builder.Index,
                Options = builder.Options,
                Classifier = builder.Classifier,
                Condition = builder.Condition,
                Icon = builder.Icon,
                Parent = builder.Parent == null ? string.Empty : GetName(builder.Parent, builder.Parent.Name),
                // Children = children,
                Parameters = parameters,
                Claims = claims,
            };

            builder.RunCustomBuildingLogic(built);

            return built;
        }

        protected virtual void RunCustomBuildingLogic(Page built)
        {
        }

        public Navigation ForParent(params string[] parent)
        {
            return this;
        }

        private static string GetName(Navigation builder, string name)
        {
            return builder.Parent == null ? name : GetName(builder.Parent, builder.Parent.Name + name);
        }

        private static string GetApplication(Navigation builder)
        {
            return builder.Parent == null ? builder.Application : GetApplication(builder.Parent);
        }

        public Navigation With(params Navigation[] children)
        {
            this.Children.AddRange(children);

            foreach (var child in children)
            {
                child.Parent = this;
            }

            return this;
        }

        protected abstract void SetOptions();

        public Navigation WithOptions(string options)
        {
            foreach (var option in options.Split(",".ToCharArray()))
            {
                this.WithOptions((PageOption)Enum.Parse(typeof(PageOption), option, true));
            }

            return this;
        }

        public Navigation OverrideName(string @override)
        {
            this.Override = @override;

            return this;
        }

        public Navigation WithOptions(PageOption options)
        {
            this.Options = this.Options.Set(options);

            return this;
        }

        public Navigation ClearOptions(PageOption option)
        {
            this.Options = this.Options.Clear(option);

            return this;
        }

        public Navigation WithClaims(params ClaimBase[] claims)
        {
            this.ClearOptions(PageOption.Anonymous);

            this.Claims.AddRange(claims);

            return this;
        }

        public Navigation Classify(string classifier)
        {
            this.Classifier = classifier;

            return this;
        }

        public Navigation Conditional(string condition)
        {
            this.Condition = condition;

            return this;
        }

        public Navigation WithIcon(string icon)
        {
            this.Icon = icon;

            return this;
        }

        public Navigation ForApplication(string application)
        {
            this.Application = application;

            return this;
        }

        public Navigation Anonymous()
        {
            return this.WithOptions(PageOption.Anonymous);
        }

        public Navigation Hidden()
        {
            return this.WithOptions(PageOption.Hidden);
        }

        public Navigation Indexed(int index)
        {
            this.Index = index;

            return this;
        }

        public Navigation Default()
        {
            return this.WithOptions(PageOption.Default);
        }

        public Navigation NotNavigable()
        {
            return this.WithOptions(PageOption.NotNavigable);
        }
    }
}
