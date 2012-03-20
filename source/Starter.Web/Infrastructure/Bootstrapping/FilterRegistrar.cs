using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Web;

namespace Starter.Web.Infrastructure
{
    public class FilterRegistrar : FilterRegistrarBase
    {
        public override IFilterRegistrar RegisterFilters(GlobalFilterCollection filters)
        {
            return this;
        }
    }
}