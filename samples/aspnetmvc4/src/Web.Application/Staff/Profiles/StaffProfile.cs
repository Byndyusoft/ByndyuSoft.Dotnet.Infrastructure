namespace Mvc4Sample.Web.Application.Staff.Profiles
{
    using AutoMapper;
    using Domain.Entities;
    using Forms;

    public class StaffProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Staff, EditStaffForm>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
    }
}