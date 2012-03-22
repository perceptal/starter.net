using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using System.Collections.Generic;
using AutoMapper;


namespace Starter.Web.Controllers
{
    public partial class RolesController : PlatformController
    {
        public RolesController(ISecurityManager security, IConfigManager config, IPersonService service)
            : base(security, config)
        {
            this.PersonService = service;
        }

        private IPersonService PersonService { get; set; }

        public virtual ActionResult Index(int id)
        {
            var roles = this.PersonService.Get(id).User.Roles;

            var model = Mapper.Map<ICollection<Role>, IList<RoleViewModel>>(roles);

            return View(base.GetModel<RoleListViewModel>()
                .WithRoles(model));
        }
    }
}
