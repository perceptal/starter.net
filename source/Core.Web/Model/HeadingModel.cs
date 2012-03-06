using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Web
{
    /// <summary>
    /// Heading view model
    /// </summary>
    public class HeadingModel
    {
        public const string Separator = " &#x2192; ";

        /// <summary>
        /// The active page
        /// </summary>
        public Page ActivePage { get; set; }

        /// <summary>
        /// The root page
        /// </summary>
        public Page RootPage { get; set; }

        /// <summary>
        /// The page breadcrumbs
        /// </summary>
        public IEnumerable<Page> Breadcrumbs
        {
            get { return this.ActivePage.HierarchyFor(); }
        }

        // public IEntity Entity { get; set; }

        /// <summary>
        /// The title of the current page
        /// </summary>
        public string Title
        {
            get
            {
                if (this.RootPage == null)
                {
                    throw new Exception("RootPage on the HeadingModel should not be null");
                }

                return this.Text ??
                    "{0} | {1} : {2}".FormatWith(
                    this.Breadcrumbs.Select(p => p.Title).Aggregate((l, r) => l + " &#187; " + r),
                    this.RootPage.Title,
                    this.RootPage.Description);
            }
        }

        /// <summary>
        /// Provides a mechanism to override the heading text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Link options for heading links
        /// </summary>
        public LinkOption GetLinkOptionsFor(Page page)
        {
            var options = LinkOption.None;

            if (page == this.Breadcrumbs.Last() && this.Breadcrumbs.Count() > 1)
            {
                options = options.Set(LinkOption.Selected);
            }

            if (page == this.Breadcrumbs.First())
            {
                options = options.Set(LinkOption.First);
            }

            if (page == this.Breadcrumbs.Last())
            {
                options = options.Set(LinkOption.Last);
            }

            return options;
        }
    }
}
