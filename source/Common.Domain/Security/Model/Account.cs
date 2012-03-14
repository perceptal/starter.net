using System;
using System.Collections.Generic;
using Core;
using Core.Domain;

namespace Common.Domain
{
    public class Account : ValueObject<Account>
    {
        protected Account() {}

        public Account(string identity, Site site)
        {
            Enforce.Argument(() => identity, "identity");
            Enforce.ArgumentNotNull(() => site, "site");

            this.Identity = identity;
            this.Site = site;
        }

        public string Identity { get; private set; }

        public Site Site { get; private set; }

        protected override IEnumerable<object> Reflect()
        {
            yield return Identity;
            yield return Site;
        }
    }

    public enum Site
    {
        Twitter,
        Facebook,
        Flickr,
        Vimeo,
        YouTube,
        Pinterest,
        Instagram,
        Foursquare,
        GitHub
    }
}
