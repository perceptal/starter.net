using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Person : Entity
    {
        public Person()
        {
            this.Accounts = new HashSet<Account>();
        }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string KnownAs { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Marital MaritalStatus { get; set; }

        public virtual string Title { get; set; }

        public virtual string Uri { get; set; }

        public virtual DateTime? Dob { get; set; }

        public virtual SecurityKey SecurityKey { get; set; }

        public virtual DateTime? LeftOn { get; set; }

        public virtual Email Email { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }

    public enum Gender 
    {
        Male,
        Female
    }

    public enum Marital 
    {
        Single,
        Married,
        Divorced,
        Widowed,
        Separated
    }

    public enum Title
    {
        Mr,
        Mrs,
        Miss,
        Ms,
        Dr
    }
}
