using System;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Web.Config;
using Core.Web.Security;
using web = System.Web.Mvc;

namespace Core.Web
{
    public abstract class PlatformController : web.Controller
    {
        private const string RemoteMaster = "Remote";
        private const string ApplicationMaster = "Application";

        protected PlatformController(ISecurityManager security, IConfigManager config)
        {
            this.Security = security;
            this.Config = config;
        }

        public ISecurityManager Security { get; set; }

        public IConfigManager Config { get; private set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool IsAjaxRequest { get; private set; }

        public bool IsJsonRequest { get; private set; }

        public bool IsModelPopulated { get; private set; }

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

        protected override ViewResult View(IView view, object model)
        {
            return base.View(view, CheckModel(model));
        }

        protected override ViewResult View(string view, string master, object model)
        {
            return base.View(view, this.GetMaster(master), CheckModel(model));
        }

        private string GetMaster(string master)
        {
            if (this.IsAjaxRequest)
            {
                return RemoteMaster;
            }

            return master.IsNullOrEmpty() ? ApplicationMaster : master;
        }

        private object CheckModel(object model)
        {
            if (model == null)
            {
                model = this.GetModel();
            }

            if (!(model is ViewModelBase))
            {
                throw new InvalidOperationException("Model data must have been populated using GetModel<TViewModel>()");
            }

            return model;
        }

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
            return model
                //.WithIdentity(this.Principal.Identity)
                .WithRoute(this.ControllerName, this.ActionName)
                .WithNavigation(this.Config.Navigation) as T;
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
