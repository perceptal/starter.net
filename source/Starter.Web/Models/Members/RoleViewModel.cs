using System;
using Core.Web;
using System.Collections.Generic;

namespace Starter.Web
{
    public class RoleViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PersonId { get; set; }
    }

    public class RoleListViewModel : ViewModelBase
    {
        public RoleListViewModel WithRoles(IList<RoleViewModel> roles)
        {
            this.Roles = roles;
            return this;
        }

        public IList<RoleViewModel> Roles { get; set; }
    }
}