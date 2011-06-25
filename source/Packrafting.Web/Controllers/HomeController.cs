using System.Web.Mvc;
using Common.Domain;

namespace Packrafting.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMembershipService service)
        {
            this.Service = service;
        }

        private IMembershipService Service { get; set; }

        public ActionResult Index()
        {
            var member = new Member() { Name = "Johnny Hall", Email = "johnny@recipher.co.uk" };
            member.Accounts.Add(new Account("recipher", Site.Twitter));
            // member.Role = new Role() { Name = "administrator" };

            this.Service.Register(member);

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
