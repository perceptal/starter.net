using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Web
{
    public class NavigationModel
    {
        public NavigationModel(Page navigation)
        {
            this.Navigation = navigation;
        }

        private Page Navigation { get; set; }

        public Page Get(string key)
        {
            return this.Navigation;
        }
    }
}
