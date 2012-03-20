using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Core.Web;

namespace Starter.Web
{
    public class OrganisationViewModel : ViewModelBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public MvcHtmlString Link(string action, string text)
        {
            var link = new TagBuilder("a");

            link.AddCssClass(action);
            link.MergeAttribute("href", "/administration/organisations/{1}/{0}".FormatWith(this.Id, action));
            link.SetInnerText(text);

            return new MvcHtmlString(link.ToString());
        }
    }

    public class OrganisationListViewModel : ViewModelBase
    {
        public OrganisationListViewModel WithOrganisations(IList<OrganisationViewModel> organisations)
        {
            this.Organisations = organisations;
            return this;
        }

        public IList<OrganisationViewModel> Organisations { get; set; }
    }
}