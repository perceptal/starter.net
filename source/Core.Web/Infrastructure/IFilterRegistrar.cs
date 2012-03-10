using System.Web.Mvc;
namespace Core.Web
{
    public interface IFilterRegistrar
    {
        void RegisterGlobalFilters(GlobalFilterCollection filters);
    }
}