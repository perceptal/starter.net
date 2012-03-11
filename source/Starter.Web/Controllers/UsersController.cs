using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;

namespace Starter.Web.Controllers
{
    public class UsersController : PlatformController
    {
        public UsersController(ISecurityManager security, IConfigManager config) : base(security, config)
        {
        }

        public ActionResult Index()
        {
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult Search()
        {
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult Recent()
        {
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult Favourites()
        {
            var model = base.GetModel();

            return View(model);
        }

        public ActionResult Archive()
        {
            var model = base.GetModel();

            return View(model);
        }
    }
}
