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
            var organisations = List();

            var model = Mapper.Map<IList<Group>, IList<OrganisationViewModel>>(organisations);

            return View(base.GetModel<OrganisationListViewModel>()
                .WithOrganisations(model));
        }

        public virtual ActionResult Show(int id)
        {
            var model = Mapper.Map<Group, OrganisationViewModel>(this.GroupService.Get(id));

            return View(base.GetModel<OrganisationViewModel>(model));
        }

        public virtual ActionResult Search()
        {
            var model = base.GetModel();

            return View(model);
        }

        public virtual ActionResult Recent()
        {
            var model = base.GetModel();

            return View(model);
        }

        public virtual ActionResult Favourites()
        {
            var model = base.GetModel();

            return View(model);
        }

        public virtual ActionResult Archive()
        {
            var model = base.GetModel();

            return View(model);
        }

        private IList<Group> List()
        {
            var organisations = this.GroupService.ListOrganisations();

            if (!organisations.Any()) Seed(organisations);

            return organisations;
        }

        #region Seed the application with data

        private IList<Group> Seed(IList<Group> organisations)
        {
            var root = this.GroupService.Setup();
            var demo = this.GroupService.Register(new Group("Demo Organisation", "999999", "info@demo.com", "01896 830894"));

            var matterhorn = this.GroupService.AddGroup(new Group("Matterhorn"), demo);
            var eiger = this.GroupService.AddGroup(new Group("Eiger"), demo);
            var jorasses = this.GroupService.AddGroup(new Group("Grand Jorasses"), demo);

            var system = this.PersonService.Register(
                new Person("System", "User", "engineer@perceptal.co.uk", Gender.Male, Marital.Single, "Mr", DateTime.Today), root);

            var johnny = this.PersonService.Register(
                new Person("Johnny", "Hall", "johnny@recipher.co.uk", Gender.Male, Marital.Single, "Mr", new DateTime(1971, 5, 14))
                , root);

            johnny.AddPhoto("george".Photo(Server));

            this.PersonService.Save(johnny);

            organisations.Add(root);
            organisations.Add(demo);
          
            return organisations;
        }

        #endregion
    }

    public static class StringExtensions
    {
        public static byte[] Photo(this string name, HttpServerUtilityBase server)
        {
            return new ImageGenerator().Generate(server.MapPath("/assets/images/photos/{0}.jpg".FormatWith(name)));
        }
    }
}
