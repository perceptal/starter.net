using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Domain;
using Packrafting.Web.Models;

namespace Packrafting.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController(IAuthenticationService authentication)
        {
            this.Authentication = authentication;
        }

        private IAuthenticationService Authentication { get; set; }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SignOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignOn(SignOnModel model)
        {
            var authenticated = this.Authentication.Authenticate(new User());

            ViewBag.Message = authenticated.ToString();

            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }
    }
}
