namespace Infrastructure.OrmLite.Queries.User
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Domain.Criteria;
    using Dtos;
    using Mvc4Sample.Domain.Entities;
    using ServiceStack.OrmLite;

    public class AllUsersQuery : IQuery<AllEntities, IEnumerable<User>>
    {
        public IEnumerable<User> Ask(AllEntities criterion)
        {
            using (var connection = ConnectionFactory.Open())
            {
//                return connection
//                    .Select<UserDto>()
//                    .MapEachTo<>();
            }

            return Enumerable.Empty<User>();
        }
    }
}