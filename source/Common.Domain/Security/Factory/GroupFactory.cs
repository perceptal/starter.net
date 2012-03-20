using System;

namespace Common.Domain.Implementation
{
    public class GroupFactory : IGroupFactory
    {
        private const string System = "System";
        private const string Code = "380800";
        private const string Email = "starter@perceptal.co.uk";
        private const string Contact = "01896 830894";

        public Group CreateRoot()
        {
            return new Group
            {
                Name = System,
                Code = Code,
                Email = Email,
                Contact = Contact,
                Level = GroupLevel.System,
                SecurityKey = new SecurityKey()
            };
        }

        public Group CreateOrganisation(Group group, Group root)
        {
            return Create(group.Name, group.Code, root.Level + 1, group.Email, group.Contact, root);
        }

        public Group CreateGroup(Group group, Group parent)
        {
            return Create(group.Name, parent.Code, parent.Level + 1, group.Email, group.Contact, parent);
        }

        private Group Create(string name, string code, GroupLevel level, string email, string contact, Group parent)
        {
            return new Group
            {
                Name = name,
                Code = code,
                Level = level,
                Email = email,
                Contact = contact,
                Parent = parent,
                SecurityKey = new SecurityKey(level, parent)
            };
        }
    }
}