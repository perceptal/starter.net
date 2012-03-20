using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel;

namespace Core.Web
{
    public static class HtmlHelperExtensions
    {
        public static void RenderPartialWithData(this HtmlHelper helper, string partialViewName, object model, object viewData)
        {
            var viewDataDictionary = new ViewDataDictionary();

            if (viewData != null)
            {
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(viewData))
                {
                    object val = prop.GetValue(viewData);
                    viewDataDictionary[prop.Name] = val;
                }
            }

            helper.RenderPartial(partialViewName, model, viewDataDictionary);
        }
    }
}
