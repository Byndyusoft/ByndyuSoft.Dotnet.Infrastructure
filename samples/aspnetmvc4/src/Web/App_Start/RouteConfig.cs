namespace Web.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*allashx}", new {allashx = @".*\.ashx(/.*)?"});
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"});

            routes.MapRoute("Default", "{controller}/{action}/{id}", new {controller = "Account", action = "Profile", id = UrlParameter.Optional});
        }
    }
}