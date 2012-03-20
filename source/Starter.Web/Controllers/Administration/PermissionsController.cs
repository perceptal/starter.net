using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using System.Web;
using System.Collections.Generic;

namespace Starter.Web.Areas.Administration.Controllers
{
    public partial class PermissionsController : PlatformController
    {
        public PermissionsController(ISecurityManager security, IConfigManager config, IGroupService group)
            : base(security, config)
        {
            this.GroupService = group;
        }

        private IGroupService GroupService { get; set; }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
