using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Web
{
    /// <summary>
    /// Extensions to the page contract class to enable code to more easily determine useful information
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Determine the default page for a specific parent
        /// </summary>
        /// <param name="page">The page to search from</param>
        /// <returns>The default page</returns>
        public static Page GetDefaultChildPage(this Page page)
        {
            if (!page.Children.Any())       // No children?  Uses this page as the default
            {
                return page;
            }

            // No pages marked as default?
            if (!page.Children.Where(p => p.Options.Has(PageOption.Default)).Any())
            {
                return page.Children.Count(p => p.Options.Has(PageOption.NotNavigable)) == page.Children.Count()
                    ? page.Children.First().GetDefaultChildPage()   // If all the children are not navigable, get the default from the first child
                    : page.Children.First();                        // Otherwise just use the first child
            }

            var selected = page.Children.Where(p => p.Options.Has(PageOption.Default)).First();

            return selected.Options.Has(PageOption.NotNavigable) ? selected.GetDefaultChildPage() : selected;
        }

        /// <summary>
        /// Determine the default action for a specific parent
        /// </summary>
        /// <param name="page">The page to search from</param>
        /// <returns>The default action</returns>
        public static Page GetDefaultChildAction(this Page page)
        {
            if (page.Options.Has(PageOption.Action) || !page.Children.Any())
            {
                return page;
            }

            var defaultChildren = page.Children.Where(p => p.Options.Has(PageOption.Default));
            var child = defaultChildren.Any() ? defaultChildren.First() : page.Children.First();

            return child.GetDefaultChildAction();
        }

        /// <summary>
        /// Determine the list of actions for a particular page
        /// </summary>
        /// <param name="page">Owning page</param>
        /// <returns>The list of actions</returns>
        public static IEnumerable<Page> Actions(this Page page)
        {
            var actions = page.Children.Where(p => p.Options.Has(PageOption.Action)).ToList();

            foreach(var child in page.Children)
            {
                actions.AddRange(child.Actions());
            }

            return actions;
        }

        /// <summary>
        /// Determine the list of controllers for a particular page
        /// </summary>
        /// <param name="page">Owning page</param>
        /// <returns>The list of controllers</returns>
        public static IEnumerable<Page> Controllers(this Page page)
        {
            var controllers = page.Children.Where(p => p.Options.Has(PageOption.Controller)).ToList();

            foreach (var child in page.Children)
            {
                controllers.AddRange(child.Controllers());
            }

            return controllers;
        }

        /// <summary>
        /// Determine the controller for a particular page
        /// </summary>
        /// <param name="page">Page to find controller for</param>
        /// <returns>The controller page</returns>
        public static Page Controller(this Page page)
        {
            return (page.Options.Has(PageOption.Controller) || page.Parent == null)
                ? page
                : page; //.Parent.Controller();
        }

        /// <summary>
        /// Calculates the hierarchy for a particular page
        /// </summary>
        /// <param name="page">Page to generate the hierarchy for</param>
        /// <returns>The hierarchy as a list of pages</returns>
        public static IEnumerable<Page> HierarchyFor(this Page page)
        {
            var pages = new List<Page>();

            while (page != null)
            {
                if (!page.Options.Has(PageOption.NotNavigable))
                {
                    pages.Add(page);
                }

                //page = page.Parent;
            }

            // We have to reverse because we start at the bottom
            pages.Reverse();

            return pages;
        }

        /// <summary>
        /// Determines if a page is in the hierarchy list of another page
        /// </summary>
        /// <param name="left">First page</param>
        /// <param name="right">Second page</param>
        /// <returns>Boolean indicating success or failure</returns>
        public static bool IsInHierarchyOf(this Page left, Page right)
        {
            return right.HierarchyFor().Select(p => p.Name).Contains(left.Name);
        }
    }
}
