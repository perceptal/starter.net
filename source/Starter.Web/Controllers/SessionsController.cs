using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using Starter.Web.Models;

namespace Starter.Web.Controllers
{
    public class SessionsController : PlatformController
    {
        public SessionsController(ISecurityManager security, IConfigManager config)
            : base(security, config)
        {
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SignOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignOn(SignOnModel model)
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}
