namespace MvcSample.Web.Application.Map.Profiles
{
	using Account.Forms;
	using AutoMapper;
	using Domain.Entities;

	public class UserProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<User, UserViewModel>()
				.ForMember(x => x.Name, x => x.MapFrom(z => z.Name));
		}
	}
}