using System.Web.Mvc;
using Common.Domain;

namespace Packrafting.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMemberRepository repo)
        {
            this.Repository = repo;
        }

        private IMemberRepository Repository { get; set; }

        public ActionResult Index()
        {
            this.Repository.Submit(new Member() { Name = "Johnny Hall" });

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
