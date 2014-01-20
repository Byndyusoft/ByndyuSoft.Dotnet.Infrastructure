namespace Mvc4Sample.Infrastructure.OrmLite.User.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Dapper;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Entities;
    using Dtos;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.SqlServer;
    using Web.Application.Account.Criteria;

    public class FindByLoginQuery : IQuery<FindByLogin, User>
    {
        public User Ask(FindByLogin criterion)
        {
            OrmLiteConfig.DialectProvider = new SqlServerOrmLiteDialectProvider();

            using (var connection = new ConnectionFactory().Create())
            {
                var userDto = connection.Select<UserDto>(x => x.LOGIN == criterion.Login)
                                        .Single();

                var result = new User(userDto.NAME, userDto.EMAIL, userDto.LOGIN)
                    {
                        Id = userDto.USER_ID
                    };

                result.SetPassword(new Password(userDto.PASSWORD_HASH, userDto.PASSWORD_SALT));

                return result;
            }
        }
    }
}