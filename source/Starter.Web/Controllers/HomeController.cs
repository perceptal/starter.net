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
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult About()
        {
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult Contact()
        {
            var model = base.GetModel();

            return View(model);
        }
    }
}
