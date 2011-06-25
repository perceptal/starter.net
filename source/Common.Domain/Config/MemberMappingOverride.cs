using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class MemberMappingOverride : IAutoMappingOverride<Member>
    {
        public void Override(AutoMapping<Member> mapping)
        {
            mapping.HasMany<Account>(member => member.Accounts)
                .Table("[Account]")
                .Component(c =>
                    {
                        c.Map(account => account.Identity).Column("[Identity]");
                        c.Map(account => account.Site).CustomType(typeof(Site));
                    })
                .KeyColumns.Add("MemberId")
                .AsSet();
        }
    }
}
