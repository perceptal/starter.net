using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;

namespace Starter.Web.Controllers
{
    public partial class MembersController : PlatformController
    {
        public MembersController(ISecurityManager security, IConfigManager config) : base(security, config)
        {
        }

        public virtual ActionResult Index()
        {
            var model = base.GetModel()
                .WithInformationalMessage("This is an information message");

            return View(model);
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
    }
}
