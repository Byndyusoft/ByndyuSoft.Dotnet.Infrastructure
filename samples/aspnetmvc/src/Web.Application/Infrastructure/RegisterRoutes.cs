namespace MvcSample.Web.Application.Infrastructure
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcExtensions;

    public class RegisterRoutes : RegisterRoutesBase
    {
        public RegisterRoutes(RouteCollection routes)
            : base(routes)
        {
        }

        protected override void Register()
        {
            Routes.IgnoreRoute("{*allashx}", new {allashx = @".*\.ashx(/.*)?"});
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Routes.IgnoreRoute("{*favicon}", new {favicon = @"(.*/)?favicon.ico(/.*)?"});

            Routes.MapRoute("Default", "{controller}/{action}/{id}", new {controller = "Static", action = "Index", id = UrlParameter.Optional});
        }
    }
}