using System;
using System.Collections.Generic;
using Core.Domain;

namespace Common.Domain
{
    public class Person : Entity
    {
        public Person()
        {
            this.Photos = new HashSet<Photo>();
            this.Accounts = new HashSet<Account>();
            this.Contacts = new HashSet<Contact>();
        }

        public Person(Person person)
            : this(person.FirstName, person.LastName, person.Email, person.Gender, person.MaritalStatus,
                person.Title, person.Dob.Value)
        {
        }

        public Person(string firstName, string lastName, string email, Gender gender, Marital marital, string title, DateTime dob) : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.MaritalStatus = marital;
            this.Title = title;
            this.Dob = dob;
        }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FullName
        {
            get { return "{0} {1}".FormatWith(this.FirstName, this.LastName); }
        }

        public virtual string KnownAs { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Marital MaritalStatus { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime? Dob { get; set; }

        public virtual SecurityKey SecurityKey { get; set; }

        public virtual DateTime? LeftOn { get; set; }

        public virtual Email Email { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual Person AddPhoto(byte[] image)
        {
            var photo = new Photo(this.FullName, image) { Person = this };
            this.Photos.Add(photo);
            return this;
        }
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
