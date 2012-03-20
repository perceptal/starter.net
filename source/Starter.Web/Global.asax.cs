using System;
using System.Web;
using Starter.Web.Infrastructure;

namespace Starter.Web
{
    public class WebApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Bootstrapper().Bootstrap("starter");    
        }
    }
}