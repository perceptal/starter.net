using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Common.Domain.Config
{
    public class PhotoMappingOverride : IAutoMappingOverride<Photo>
    {
        public void Override(AutoMapping<Photo> mapping)
        {
            mapping.Map(p => p.Image).CustomType("BinaryBlob");
        }
    }
}
