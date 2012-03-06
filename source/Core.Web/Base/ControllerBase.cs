using System;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web.Config;
using Core.Web.Security;

namespace Core.Web
{
    public abstract class ControllerBase : System.Web.Mvc.Controller
    {
        private const string AjaxMaster = "/Layouts/_Ajax";
        private const string DefaultMaster = "/Layouts/_Layout";

        protected ControllerBase(ISecurityManager security, IConfigManager config)
        {
            this.Security = security;
            this.Config = config;
        }

        protected ISecurityManager Security { get; set; }

        protected IConfigManager Config { get; private set; }

        public virtual string ControllerName { get; set; }

        public virtual string ActionName { get; set; }

        public virtual bool IsAjaxRequest { get; private set; }

        public virtual bool IsJsonRequest { get; private set; }

        protected override void Initialize(RequestContext requestContext)  
        {  
            base.Initialize(requestContext);
        }  

        protected override void Execute(RequestContext context)
        {
            ProcessHeaders(context.HttpContext.Request.Headers);
            DetermineControllerAndAction(context.RouteData);

            base.Execute(context);
        }

        //protected override ViewResult View(IView view, object model)
        //{
        //    if (!(model is ViewModelBase) || ((ViewModelBase)model).Identity == null)
        //    {
        //        throw new InvalidOperationException("Model data must have been populated using GetModel<TViewModel>()");
        //    }

        //    return base.View(view, model);
        //}

        protected override ViewResult View(string view, string master, object model)
        {
            master = this.GetMaster(master);

            return base.View(view, master, model);
        }

        private string GetMaster(string master)
        {
            if (this.IsAjaxRequest)
            {
                return AjaxMaster;
            }

            return string.IsNullOrEmpty(master) ? DefaultMaster : master;
        }

        //protected virtual RedirectToRouteResult RedirectToHome()
        //{
        //    return RedirectToHome(string.Empty);
        //}

        //protected virtual RedirectToRouteResult RedirectToHome(string message)
        //{
        //    var home = this.Config.Navigation.GetRootPage().GetDefaultChildAction();

        //    return this.RedirectToAction(
        //        home.Override,
        //        home.Controller().Override);
        //}

        //protected virtual RedirectToRouteResult RedirectToDefault()
        //{
        //    return this.RedirectToDefault(string.Empty);
        //}

        //protected virtual RedirectToRouteResult RedirectToDefault(string message)
        //{
        //    var active = this.Config.Navigation.Get(this.ControllerName, this.ActionName).Name;

        //    // TODO: Set the temp message

        //    return this.RedirectToAction(this.Config.Navigation.Default(active).Override, this.ControllerName, null);
        //}

        private void ProcessHeaders(NameValueCollection headers)
        {
            if (!headers["Ajax"].IsNullOrEmpty() ||
                "XMLHttpRequest".Equals(headers["X-Requested-With"], StringComparison.InvariantCultureIgnoreCase))
            {
                this.IsAjaxRequest = true;
            }

            if (!headers["X-IsJson"].IsNullOrEmpty())
            {
                this.IsJsonRequest = true;
            }
        }

        protected RedirectToRouteResult RedirectToAction<TController>(Expression<Action<TController>> action, object routeValues) where TController : Controller
        {
            return RedirectToRoute(action, new RouteValueDictionary(routeValues));
        }

        protected RedirectToRouteResult RedirectToRoute<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            return RedirectToRoute(action, null);
        }

        protected RedirectToRouteResult RedirectToRoute<TController>(Expression<Action<TController>> action, object routeValues) where TController : Controller
        {
            return RedirectToRoute(action, new RouteValueDictionary(routeValues));
        }

        //protected RedirectToRouteResult RedirectWithMessage<TController>(
        //    Expression<Action<TController>> action, MessageModel messages) where TController : Controller
        //{
        //    return RedirectWithMessage(action, null, messages);
        //}

        //protected RedirectToRouteResult RedirectWithMessage<TController>(
        //    Expression<Action<TController>> action, object routeValues, MessageModel messages) where TController : Controller
        //{
        //    return RedirectWithMessage(action, new RouteValueDictionary(routeValues), messages);
        //}

        //protected RedirectToRouteResult RedirectWithMessage<TController>(
        //    Expression<Action<TController>> action, RouteValueDictionary routeValues, MessageModel messages) where TController : Controller
        //{
        //    if (this.ViewData.Model == null)
        //    {
        //        this.ViewData.Model = GetModel();
        //    }

        //    var model = this.ViewData.Model as ViewModelBase;
        //    if (model == null)
        //    {
        //        throw new ArgumentException("View model must be of type ViewModelBase");
        //    }

        //    model.Messages.With(messages);

        //    return RedirectToRoute(action, routeValues);
        //}


        private void DetermineControllerAndAction(RouteData routeData)
        {
            this.ControllerName = routeData.Values[RouteKey.Controller].ToString();
            this.ActionName = routeData.Values[RouteKey.Action].ToString();
        }

        public virtual ViewModelBase GetModel()
        {
            return GetModel<ViewModelBase>();
        }

        public virtual T GetModel<T>() where T : ViewModelBase, new()
        {
            return GetModel(new T());
        }

        public virtual T GetModel<T>(T model) where T : ViewModelBase
        {
            return model;
                //.WithIdentity(this.Principal.Identity, this.Security.ListClaimsForUser())
                //.WithRoute(this.ControllerName, this.ActionName)
                //.WithAuthenticateLink(GetAuthenticateLink())
                //.WithNavigation(pageNavigationModel) as T;
        }

        private Page GetAuthenticateLink()
        {
            //var page = this.Principal.Identity.IsAuthenticated
            //           ? this.Config.Navigation.GetByOverride(PageName.SignOut).FirstOrDefault()
            //           : this.Config.Navigation.GetByOverride(PageName.SignOn).FirstOrDefault();

            //page.Description = this.Principal.Identity.IsAuthenticated
            //           ? "Logged in as " + this.Principal.Identity.User.UserName + "(" + this.Principal.Identity.User.GroupName + ")"
            //           : "Not logged in";

            //return page;

            return null;
        }

        protected override void HandleUnknownAction(string action)
        {
            //// Determine if view exists otherwise let the framework handle it (by throwing a 404 wobbly)
            //if (this.Config.Navigation.GetByOverride(this.ActionName) == null)
            //{
            //    base.HandleUnknownAction(action);
            //}

            //this.ViewData.Model = this.GetModel();
            //this.View(action).ExecuteResult(this.ControllerContext);
        }
    }
}
