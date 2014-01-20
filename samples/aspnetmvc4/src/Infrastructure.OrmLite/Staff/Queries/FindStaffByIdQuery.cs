namespace Mvc4Sample.Infrastructure.OrmLite.Staff.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Entities;
    using Dtos;
    using ServiceStack.OrmLite;
    using Web.Application.Staff.Criteria;

    public class FindStaffByIdQuery : IQuery<FindStaffById, Staff>
    {
        public Staff Ask(FindStaffById criterion)
        {
            using (var connection = new ConnectionFactory().Create())
            {
                var staffDto = connection.Select<StaffDto>(x => x.STAFF_ID == criterion.Id)
                                         .Single();

                return new Staff(staffDto.NAME, staffDto.QUANTITY, staffDto.CREATED_AT);
            }
        }
    }
}