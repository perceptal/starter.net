using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;

namespace Starter.Web.Controllers
{
    public class HomeController : PlatformController
    {
        public HomeController(ISecurityManager security, IConfigManager config) : base(security, config)
        {
        }

        public ActionResult Index()
        {
            //var member = new Member() { Name = "Johnny Hall", Email = "johnny@recipher.co.uk" };
            //member.Accounts.Add(new Account("recipher", Site.Twitter));
            // member.Role = new Role() { Name = "administrator" };

            // this.Service.Register(member);

            var model = base.GetModel();

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
