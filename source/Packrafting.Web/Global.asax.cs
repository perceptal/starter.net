using System;
using System.Web;

namespace Packrafting.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Bootstrapper().Bootstrap();    
        }
    }
}