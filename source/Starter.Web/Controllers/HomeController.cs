using System;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;

namespace Starter.Web.Controllers
{
    public partial class HomeController : PlatformController
    {
        public HomeController(ISecurityManager security, IConfigManager config, IGroupService group, IPersonService person)
            : base(security, config)
        {
            this.GroupService = group;
            this.PersonService = person;
        }

        private IGroupService GroupService { get; set; }
        private IPersonService PersonService { get; set; }

        public virtual ActionResult Index()
        {
            Seed();

            return View();
        }

        #region Seed the application with data

        private void Seed()
        {
            if (!this.GroupService.ListOrganisations().Any())
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
            }
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
