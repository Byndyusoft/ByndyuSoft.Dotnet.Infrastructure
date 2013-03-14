namespace ByndyuSoft.Infrastructure.Dapper.Criteria
{
    using ByndyuSoft.Infrastructure.Domain;

    /// <summary>
    /// 
    /// </summary>
    public class InsertEntity : ICriterion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryParams"></param>
        public InsertEntity(object queryParams)
        {
            QueryParams = queryParams;
        }

        /// <summary>
        /// 
        /// </summary>
        public object QueryParams { get; protected set; }
    }
}