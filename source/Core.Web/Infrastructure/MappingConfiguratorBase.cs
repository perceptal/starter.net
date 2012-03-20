using System;
using AutoMapper;

namespace Core.Web
{
    public class MappingConfiguratorBase : IMappingConfiguration
    {
        public virtual void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ViewModelProfile>();
            });
        }
    }

    internal class ViewModelProfile : Profile
    {
        protected override void Configure()
        {
        }
    }

    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TSink> 
            IgnoreViewModelBase<TSource, TSink>(this IMappingExpression<TSource, TSink> expression) where TSink : ViewModelBase
        {
            expression.ForMember(model => model.ControllerName, opt => opt.Ignore());
            expression.ForMember(model => model.ActionName, opt => opt.Ignore());
            expression.ForMember(model => model.Exception, opt => opt.Ignore());
            expression.ForMember(model => model.Message, opt => opt.Ignore());
            //expression.ForMember(model => model.Identity, opt => opt.Ignore());

            return expression;
        }
    }   
}
