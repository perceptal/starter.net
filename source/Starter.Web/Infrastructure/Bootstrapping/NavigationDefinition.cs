﻿using Core.Web;

namespace Starter.Web.Infrastructure
{
    public class NavigationDefinition : INavigationDefinition
    {
        public Page Get()
        {
            return Application.Named("starter", "Starter App")
                .With(Main, Account, Legal, Support);
        }
        
        private Navigation Main
        {
            get 
            { 
                return Area.Named("main").NotNavigable().With(Home, Members, Administration); 
            }
        }

        private Navigation Account
        {
            get
            {
                return Controller.Named("sessions").NotNavigable()
                    .With(
                        Action.Named("signon", "Sign On").System().Anonymous().Hidden(),
                        Action.Named("signout", "Sign Out").System().Hidden());
            }
        }

        private Navigation Legal
        {
            get
            {
                return Controller.Named("legal").NotNavigable()
                    .With(
                        Action.Named("accessibility", "Accessibility Statement").System().Anonymous(),
                        Action.Named("privacy", "Privacy Policy").System().Anonymous(),
                        Action.Named("terms", "Terms and Conditions").System().Anonymous()
                    );
            }
        }

        private Navigation Support
        {
            get
            {
                return Controller.Named("support").NotNavigable()
                    .With(
                        Action.Named("help", "Search for Help").System().Anonymous(),
                        Action.Named("about", "About this Site").System().Anonymous(),
                        Action.Named("map", "Site Map").System().Anonymous(),
                        Action.Named("confused", "Page Not Found").System().Anonymous().Hidden().WithIcon("error"),
                        Action.Named("naughty", "Access Denied").System().Anonymous().Hidden().WithIcon("error"),
                        Action.Named("trouble", "Application Error").System().Anonymous().Hidden().WithIcon("error")
                    );
            }
        }

        private Navigation Home
        {
            get 
            { 
                return Controller.Named("home").Default()
                    .With(
                        Action.Named("index"),
                        Action.Named("about"),
                        Action.Named("contact")
                        ); 
            }
        }

        private Navigation Members
        {
            get { return Area.Named("members"); }
        }

        private Navigation Administration
        {
            get
            {
                return Area.Named("administration")
                    .With(Roles, Groups);
            }
        }

        private Navigation Users
        {
            get
            {
                return Controller.Named("user", "User Management")
                    .With(
                        Action.Named("list", "Find Users")
                            .WithClaims(Reader.For("user"))
                            .With(
                                Action.Named("edit", "Edit User").Parameterized().WithIcon("edit")
                                    .WithClaims(Editor.For("user")),
                                Action.Named("delete", "Archive User").Parameterized().WithIcon("delete")
                                    .WithClaims(Deleter.For("user")).Classify("confirmation"),
                                Action.Named("reset", "Reset Password").Parameterized().WithIcon("password")
                                    .WithClaims(Editor.For("user")).Classify("json"),
                                Action.Named("lock", "Toggle Lock Status").Parameterized().WithIcon("lock")
                                    .Classify("ajax").Conditional("Locked==false")
                                    .WithClaims(Editor.For("user")),
                                Action.Named("unlock").Parameterized().OverrideName("lock").WithIcon("unlock")
                                    .Classify("ajax").Conditional("Locked==true")
                                    .WithClaims(Editor.For("user")),
                                Action.Named("roles", "Manage Roles").Parameterized().WithIcon("roles")
                                    .WithClaims(Editor.For("user"))
                             ),
                        Action.Named("register", "Register a User")
                            .WithClaims(Creator.For("user"))
                    );
            }
        }

        private Navigation Roles
        {
            get
            {
                return Controller.Named("role", "Role Management")
                    .With(
                        Action.Named("list", "List Roles")
                            .With(
                                Action.Named("edit", "Edit Role").Parameterized().WithIcon("edit"),
                                Action.Named("delete", "Archive Role").Parameterized().WithIcon("delete")
                                    .Classify("confirmation")
                            ),
                        Action.Named("add", "Add a Role")
                   );
            }
        }

        private Navigation Groups
        {
            get
            {
                return Controller.Named("group", "Group Management")
                    .With(
                        Action.Named("list", "Find Groups")
                             .With(
                                Action.Named("edit", "Edit Group").Parameterized().WithIcon("edit"),
                                Action.Named("delete", "Archive Group").Parameterized().WithIcon("delete")
                                    .Classify("confirmation")
                            ),
                        Action.Named("add", "Add a Group")
                    );
            }
        }
    }
}