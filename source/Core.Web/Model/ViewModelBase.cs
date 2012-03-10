using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Web.Config;
using Common.Domain;

namespace Core.Web
{
    /// <summary>
    /// Contains common information that every view needs
    /// </summary>
    public class ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBase()
        {
            this.Message = new MessageModel();
            this.Claims = new List<Claim>();
        }

        /// <summary>
        /// Navigation hierarchy
        /// </summary>
        public Page Navigation { get; protected set; }

        /// <summary>
        /// True if the view model has been initialised
        /// </summary>
        public bool Initialised { get; protected set; }

        /// <summary>
        /// The logged on user's claims
        /// </summary>
        public List<Claim> Claims { get; set; }

        /// <summary>
        /// The selected page
        /// </summary>
        public Page ActivePage
        {
            get
            {
                return null; // this.Navigation.ActivePage;
            }
        }

        /// <summary>
        /// The root page
        /// </summary>
        public Page RootPage
        {
            get
            {
                return null; // this.Navigation.RootPage;
            }
        }

        /// <summary>
        /// The root page
        /// </summary>
        public Page HomePage
        {
            get
            {
                return null; // this.PageNavigation.HomePage;
            }
        }

        /// <summary>
        /// IEnumerable<PageContract/>
        /// </summary>
        public IEnumerable<Page> Actions
        {
            get
            {
                return null; // this.Navigation.Actions;
            }
        }

        /// <summary>
        /// All the navigation organised by the parent name
        /// </summary>
        public IDictionary<string, NavigationModel> Pages
        {
            get
            {
                return null; // this.PageNavigation.Pages;
            }
        }

        /// <summary>
        /// The heading for the current page
        /// </summary>
        public HeadingModel Heading
        {
            get
            {
                return null; // this.PageNavigation.Heading;
            }
        }

        /// <summary>
        /// The title for the current page
        /// </summary>
        public string Title
        {
            get
            {
                return null; // this.PageNavigation.Title;
            }
        }

        /// <summary>
        /// Determines which area of the application the user is in
        /// </summary>
        public string Area
        {
            get
            {
                return null; // this.PageNavigation.Area;
            }
        }

        /// <summary>
        /// The currently logged on user
        /// </summary>
        //public IPlatformIdentity Identity { get; set; }

        /// <summary>
        /// Controller
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Any exception information
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// The message information that will be used for display in a message box
        /// </summary>
        public MessageModel Message { get; private set; }

        /// <summary>
        /// Special link used for authentication (signon and signoff)
        /// </summary>
        public Page Authenticate { get; set; }

        /// <summary>
        /// Sets the initialised flag
        /// </summary>
        /// <returns>this</returns>
        public ViewModelBase Initialise()
        {
            this.Initialised = true;
            return this;
        }

        /// <summary>
        /// Used for authorisation against a claim
        /// </summary>
        protected bool HasClaim(string claim)
        {
            return true; // this.Claims.Contains(claim);
        }

        /// <summary>
        /// Used for authorisation against a claim
        /// </summary>
        protected bool HasClaim(string name, Right right)
        {
            return this.Claims.Contains(new Claim(name, right));
        }

        /// <summary>
        /// Used for authorisation against claims
        /// </summary>
        protected bool HasClaims(IList<string> claims)
        {
            return true; // !claims.Except(this.Claims).Any();
        }

        /// <summary>
        /// Used for authorisation against claims
        /// </summary>
        protected bool HasClaims(IList<KeyValuePair<string, Right>> claims)
        {
            var convertedClaims = claims.Select(c => new Claim(c.Key, c.Value).ToString()).ToList();
            return HasClaims(convertedClaims);
        }

        /// <summary>
        /// Used to initialise the identity
        /// </summary>
        //public ViewModelBase WithIdentity(IPlatformIdentity identity, List<string> claims)
        //{
        //    this.Identity = identity;
        //    this.Claims = claims;

        //    return this;
        //}

        /// <summary>
        /// Set route information
        /// </summary>
        public virtual ViewModelBase WithRoute(string controller, string action)
        {
            this.ControllerName = controller;
            this.ActionName = action;

            return this;
        }

        /// <summary>
        /// Used to initialise the navigation information
        /// </summary>
        public ViewModelBase WithNavigation(Page navigation)
        {
            this.Navigation = navigation;

            return this;
        }

        ///// <summary>
        ///// Used to initialise the navigation information
        ///// </summary>
        //public ViewModelBase WithNavigation(PageListContract navigation, PageContract active)
        //{
        //    this.PageNavigation = new PageNavigationModel(navigation, active);

        //    return this;
        //}

        /// <summary>
        /// Used to instantiate the authenticate link
        /// </summary>
        public ViewModelBase WithAuthenticateLink(Page autheticate)
        {
            this.Authenticate = autheticate;
            return this;
        }

        /// <summary>
        /// Filter pages by claims
        /// </summary>
        public IEnumerable<Page> FilterPagesByClaims(IEnumerable<Page> pages)
        {
            var filtered = new List<Page>();

            foreach (var page in pages)
            {
                var claims = page.Claims.Select(c => c.ToString()).ToList();

                //if (!claims.Any() || !claims.Except(this.Claims).Any())
                //{
                //    filtered.Add(page);
                //}
            }

            return filtered;
        }

        /// <summary>
        /// Set this heading
        /// </summary>
        public ViewModelBase WithHeading(HeadingModel heading)
        {
            //this.PageNavigation.Heading = heading;

            return this;
        }

        /// <summary>
        /// Set the exception
        /// </summary>
        public ViewModelBase WithException(Exception ex)
        {
            this.Exception = ex;

            return this;
        }

        /// <summary>
        /// Set a message
        /// </summary>
        public ViewModelBase WithMessage(MessageModel message)
        {
            this.Message = message;

            return this;
        }

        /// <summary>
        /// Set the message text as informational
        /// </summary>
        public ViewModelBase WithInformationalMessage(string text)
        {
            this.Message = new MessageModel { Text = text, Classifier = MessageClassifier.Information };

            return this;
        }

        /// <summary>
        /// Set an exclamation message
        /// </summary>
        public ViewModelBase WithWarningMessage(string text)
        {
            this.Message = new MessageModel { Text = text, Classifier = MessageClassifier.Exclamation };

            return this;
        }

        /// <summary>
        /// Set an error message
        /// </summary>
        public ViewModelBase WithErrorMessage(string text)
        {
            this.Message = new MessageModel { Text = text, Classifier = MessageClassifier.Error };

            return this;
        }

        /// <summary>
        /// Link options for the special authentication link
        /// </summary>
        public LinkOption GetLinkOptionsForAuthenticate()
        {
            var options = LinkOption.First;

            if (this.Authenticate.IsInHierarchyOf(this.ActivePage))
            {
                options = options.Set(LinkOption.First);
            }

            return options;
        }
    }
}