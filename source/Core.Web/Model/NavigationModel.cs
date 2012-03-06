using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Web
{
    /// <summary>
    /// Represents navigation information for the views
    /// </summary>
    public class NavigationModel
    {
        /// <summary>
        /// The currently active page
        /// </summary>
        public Page ActivePage { get; set; }

        /// <summary>
        /// This set of navigation pages' parent
        /// </summary>
        public Page ParentPage { get; set; }

        /// <summary>
        /// A set of related pages
        /// </summary>
        public IEnumerable<Page> Pages { get; set; }

        /// <summary>
        /// Required to determine whether to disable a link or not
        /// </summary>
        public bool IsAuthenticated { private get; set; }

        /// <summary>
        /// Determine link options (used for rendering)
        /// </summary>
        public LinkOption GetLinkOptionsFor(Page page)
        {
            return GetLinkOptionsFor(page, this.Pages);
        }

        /// <summary>
        /// Determine link options (used for rendering)
        /// </summary>
        public LinkOption GetLinkOptionsFor(Page page, IEnumerable<Page> pages)
        {
            var options = LinkOption.None;

            if (page.IsInHierarchyOf(this.ActivePage))
            {
                options = options.Set(LinkOption.Selected);
            }

            if (!(page.Options.Has(PageOption.Anonymous) || this.IsAuthenticated))
            {
                options = options.Set(LinkOption.Disabled);
            }

            if (page == pages.First())
            {
                options = options.Set(LinkOption.First);
            }

            if (page == pages.Last())
            {
                options = options.Set(LinkOption.Last);
            }

            return options;
        }

        /// <summary>
        /// Link options for the account link
        /// </summary>
        public LinkOption GetLinkOptionsForAccount(Page page)
        {
            return this.GetLinkOptionsFor(page).Clear(LinkOption.First);
        }
    }
}