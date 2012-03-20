using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Web;

namespace Core.Web
{
    public abstract class FilterRegistrarBase : IFilterRegistrar
    {
        public IFilterRegistrar RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            return this;
        }

        public abstract IFilterRegistrar RegisterFilters(GlobalFilterCollection filters);
    }
}