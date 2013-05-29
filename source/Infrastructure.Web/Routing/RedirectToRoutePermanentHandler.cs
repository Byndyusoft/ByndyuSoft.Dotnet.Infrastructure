namespace ByndyuSoft.Infrastructure.Web.Routing
{
    using System.Web;
    using System.Web.Routing;

    /// <summary>
    ///     Обработчик постоянного перенаправления на заданный маршрут
    /// </summary>
    public class RedirectToRoutePermanentHandler : IRouteHandler, IHttpHandler
    {
        private readonly RouteValueDictionary _routeDictionary;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="routes"></param>
        public RedirectToRoutePermanentHandler(object routes)
            : this(new RouteValueDictionary(routes))
        {
        }

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="routeDictionary"></param>
        public RedirectToRoutePermanentHandler(RouteValueDictionary routeDictionary)
        {
            _routeDictionary = routeDictionary;
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            context.Response.RedirectToRoutePermanent(_routeDictionary);
        }

        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }
}