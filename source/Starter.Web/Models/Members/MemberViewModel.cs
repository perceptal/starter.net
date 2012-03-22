using System;
using Core.Web;
using System.Collections.Generic;

namespace Starter.Web
{
    public class MemberViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }
    }

    public class MemberListViewModel : ViewModelBase
    {
        public MemberListViewModel WithMembers(IList<MemberViewModel> members)
        {
            this.Members = members;
            return this;
        }

        public IList<MemberViewModel> Members { get; set; }
    }
}