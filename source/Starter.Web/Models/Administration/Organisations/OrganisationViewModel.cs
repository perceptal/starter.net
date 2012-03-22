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