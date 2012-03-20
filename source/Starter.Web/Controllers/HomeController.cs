﻿using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;

namespace Starter.Web.Controllers
{
    public partial class HomeController : PlatformController
    {
        public HomeController(ISecurityManager security, IConfigManager config) : base(security, config)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
