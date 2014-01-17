namespace Mvc4Sample.Infrastructure.OrmLite.Dtos
{
    using ServiceStack.DataAnnotations;

    [Alias("USERS")]
    public class UserDto
    {
        public int USER_ID { get; set; }

        public string NAME { get; set; }

        public string LOGIN { get; set; }

        public string EMAIL { get; set; }

        public string PASSWORD_HASH { get; set; }

        public string PASSWORD_SALT { get; set; }
    }
}