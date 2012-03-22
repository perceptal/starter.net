using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using System.Collections.Generic;
using AutoMapper;

namespace Starter.Web.Controllers
{
    public partial class MembersController : PlatformController
    {
        public MembersController(ISecurityManager security, IConfigManager config, IPersonService service) : base(security, config)
        {
            this.Service = service;
        }

        private IPersonService Service { get; set; }

        public virtual ActionResult Index()
        {
            return Populate(this.Service.List());
        }

        public virtual ActionResult Show(int id)
        {
            var model = Mapper.Map<Person, MemberViewModel>(this.Service.Get(id));

            return View(base.GetModel<MemberViewModel>(model));
        }

        public virtual JsonResult Search(string query)
        {
            return new JsonResult { Data = this.Service.Search(query) };
        }

        public virtual ActionResult Recent()
        {
            return Populate(this.Service.Recent(0));
        }

        public virtual ActionResult Favourites()
        {
            return Populate(this.Service.Favourites(0));
        }

        public virtual ActionResult Archived()
        {
            return Populate(this.Service.Archived());
        }

        private ActionResult Populate(IList<Person> people)
        {
            var model = Mapper.Map<IList<Person>, IList<MemberViewModel>>(people);

            return View(base.GetModel<MemberListViewModel>()
                .WithMembers(model));
        }
    }
}
