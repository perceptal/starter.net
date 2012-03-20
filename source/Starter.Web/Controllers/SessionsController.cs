using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using Starter.Web.Models;

namespace Starter.Web.Controllers
{
    public partial class SessionsController : PlatformController
    {
        public SessionsController(ISecurityManager security, IConfigManager config)
            : base(security, config)
        {
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult New()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(SignOnModel model)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public virtual ActionResult Destroy()
        {
            return View();
        }
    }
}
