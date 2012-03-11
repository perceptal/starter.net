using System.Web.Mvc;

namespace Starter.Web.Areas.Administration
{
    public class Administration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "administration"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "administration_default",
                "administration/{controller}/{action}/{id}",
                new { controller = "organisations", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
