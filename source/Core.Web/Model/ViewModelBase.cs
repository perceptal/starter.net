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
        }

        /// <summary>
        /// Navigation hierarchy
        /// </summary>
        public NavigationModel Navigation { get; protected set; }

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
            this.Navigation = new NavigationModel(navigation);

            return this;
        }

        /// <summary>
        /// Set the exception
        /// </summary>
        public ViewModelBase WithException(Exception ex)
        {
            this.Exception = ex;
            return WithErrorMessage(ex.Message);
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
    }
}