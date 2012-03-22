using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using System.Web;
using System.Collections.Generic;

namespace Starter.Web.Areas.Administration.Controllers
{
    public partial class OrganisationsController : PlatformController
    {
        public OrganisationsController(ISecurityManager security, IConfigManager config, IGroupService group, IPersonService person)
            : base(security, config)
        {
            this.GroupService = group;
            this.PersonService = person;
        }

        private IGroupService GroupService { get; set; }
        private IPersonService PersonService { get; set; }

        public virtual ActionResult Index()
        {
            return Populate(this.GroupService.ListOrganisations());
        }

        public virtual ActionResult Show(int id)
        {
            var model = Mapper.Map<Group, OrganisationViewModel>(this.GroupService.Get(id));

            return View(base.GetModel<OrganisationViewModel>(model));
        }

        public virtual JsonResult Search()
        {
            return new JsonResult { Data = this.GroupService.ListOrganisations() };
        }

        public virtual ActionResult Recent()
        {
            return Populate(this.GroupService.ListOrganisations());
        }

        public virtual ActionResult Favourites()
        {
            return Populate(this.GroupService.ListOrganisations());
        }

        public virtual ActionResult Archive()
        {
            return Populate(this.GroupService.ListOrganisations());
        }

        private ActionResult Populate(IList<Group> organisations)
        {
            var model = Mapper.Map<IList<Group>, IList<OrganisationViewModel>>(organisations);

            return View(base.GetModel<OrganisationListViewModel>()
                .WithOrganisations(model));
        }
    }
}
