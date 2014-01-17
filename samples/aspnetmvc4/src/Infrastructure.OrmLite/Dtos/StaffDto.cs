namespace Mvc4Sample.Infrastructure.OrmLite.Dtos
{
    using System;
    using ServiceStack.DataAnnotations;

    [Alias("STAFF")]
    public class StaffDto
    {
        public int STAFF_ID { get; set; }

        public string NAME { get; set; }

        public int QUANTITY { get; set; }

        public DateTime CREATED_AT { get; set; }
    }
}