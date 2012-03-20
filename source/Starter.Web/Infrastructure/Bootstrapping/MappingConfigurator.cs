using System;
using AutoMapper;
using Core.Web;
using Common.Domain;

namespace Starter.Web.Infrastructure
{
    public class MappingConfigurator : MappingConfiguratorBase
    {
        public override void Configure()
        {
            base.Configure();

            Organisations();
            Members();
        }

        private void Organisations()
        {
            Mapper.CreateMap<Group, OrganisationViewModel>()
                .IgnoreViewModelBase()
                .ForMember(model => model.Email, opt => opt.MapFrom(entity => entity.Email.Value))
                .ForMember(model => model.ContactNumber, opt => opt.MapFrom(entity => entity.Contact.Number));
        }

        private void Members()
        {
            Mapper.CreateMap<Person, MemberViewModel>()
                .IgnoreViewModelBase()
                .ForMember(model => model.UserName, opt => opt.MapFrom(entity => entity.User.Username))
                .ForMember(model => model.Email, opt => opt.MapFrom(entity => entity.Email.Value));
        }
    }
}