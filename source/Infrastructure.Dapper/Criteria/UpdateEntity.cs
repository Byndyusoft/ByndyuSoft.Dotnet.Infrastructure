namespace ByndyuSoft.Infrastructure.Dapper.Criteria
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateEntity: InsertEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryParams"></param>
        public UpdateEntity(object queryParams)
            : base(queryParams)
        {
        }
    }
}