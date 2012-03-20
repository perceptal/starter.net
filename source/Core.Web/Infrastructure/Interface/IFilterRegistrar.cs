using System.Web.Mvc;
namespace Core.Web
{
    public interface IFilterRegistrar
    {
        IFilterRegistrar RegisterGlobalFilters(GlobalFilterCollection filters);
        IFilterRegistrar RegisterFilters(GlobalFilterCollection filters);
    }
}