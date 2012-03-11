using System;
using System.Web.Mvc;

namespace Core.Web
{
    public class PlatformViewEngine : RazorViewEngine
    {
        public PlatformViewEngine()
        {
            this.ViewLocationFormats = new string[] 
            {
                "~/Views/{1}/{0}.cshtml"
            };

            this.PartialViewLocationFormats = new string[] 
            {
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{0}.cshtml"
            };

            this.MasterLocationFormats = new string[] 
            {
                "~/Views/Layouts/{0}.cshtml"
            };

            this.AreaViewLocationFormats = new string[] 
            {
                "~/Views/{2}/{1}/{0}.cshtml"
            };

            this.AreaPartialViewLocationFormats = new string[] 
            {
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{2}/Shared/{0}.cshtml",
                "~/Views/{2}/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/{0}.cshtml"
            };

        }
    }
}
