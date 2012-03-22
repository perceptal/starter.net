using System.Web.Mvc;
using Common.Domain;
using Core.Web;
using Core.Web.Security;
using Core.Web.Config;
using System.Collections.Generic;
using AutoMapper;

namespace Starter.Web.Controllers
{
    public partial class PhotosController : PlatformController
    {
        public PhotosController(ISecurityManager security, IConfigManager config, IPersonService service) : base(security, config)
        {
            this.PersonService = service;
        }

        private IPersonService PersonService { get; set; }

        public virtual ActionResult Index(int id)
        {
            var photos = this.PersonService.Get(id).Photos;

            var model = Mapper.Map<ICollection<Photo>, IList<PhotoViewModel>>(photos);

            return View(base.GetModel<PhotoListViewModel>()
                .WithPhotos(model));
        }
    }
}
