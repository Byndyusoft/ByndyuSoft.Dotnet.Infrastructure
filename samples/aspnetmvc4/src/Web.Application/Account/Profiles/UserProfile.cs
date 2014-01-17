namespace Mvc4Sample.Web.Application.Account.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Forms;

    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Name));
        }
    }
}