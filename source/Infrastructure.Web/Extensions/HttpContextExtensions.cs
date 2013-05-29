namespace ByndyuSoft.Infrastructure.Web.Extensions
{
    using System.Web;

    /// <summary>
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        ///     Проверка аутентифицирован пользователь
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsAuthenticated(this HttpContextBase context)
        {
            return context.User != null && context.User.Identity.IsAuthenticated;
        }
    }
}