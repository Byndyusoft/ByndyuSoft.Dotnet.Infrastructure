namespace Mvc4Sample.Web.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Account.Services.Impl;

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly IEnumerable<RoleType> roleTypes;

        public CustomAuthorizeAttribute(params RoleType[] roleTypes)
        {
            this.roleTypes = roleTypes;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (httpContext.User == null)
                return false;

            if (roleTypes.Any())
            {
                return roleTypes.Any(x => httpContext.User.IsInRole(x.ToString()));
            }

            return httpContext.Request.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;

            string appPath = context.Request.ApplicationPath == "/"
                                 ? string.Empty
                                 : context.Request.ApplicationPath;

            string loginUrl = FormsAuthentication.LoginUrl;
            string path = HttpUtility.UrlEncode(context.Request.Url.PathAndQuery);

            string url = String.Format("{0}{1}?ReturnUrl={2}", appPath, loginUrl, path);

            if (filterContext.IsChildAction == false)
                filterContext.Result = new RedirectResult(url);
        }
    }
}