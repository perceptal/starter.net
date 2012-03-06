using System;
using System.Web;

namespace Starter.Web
{
    public class WebApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Bootstrapper().Bootstrap();    
        }
    }
}