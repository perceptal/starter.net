using System;

namespace Common.Domain
{
    public interface IPersonFactory
    {
        Person Create(Person person, Group group, User user);
    }
}
