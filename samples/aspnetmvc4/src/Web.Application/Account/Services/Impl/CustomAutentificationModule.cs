namespace Mvc4Sample.Web.Application.Account.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;

    /// <summary>
    /// Извлекает информацию о пользователе из тикета.
    /// </summary>
    public sealed class CustomAutentificationModule : IHttpModule
    {
        public void Init(HttpApplication httpApplication)
        {
            httpApplication.AuthenticateRequest += OnAuthenticateRequest;
        }

        public void Dispose()
        {
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;

            HttpContext context = application.Context;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            string cookieName = FormsAuthentication.FormsCookieName;

            HttpCookie cookie = application.Request.Cookies[cookieName.ToUpper()];

            if (cookie == null)
                return;
            try
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var identity = new CustomIdentity(AccountEntry.Deserialize(ticket.UserData), ticket.Name);
                var principal = new GenericPrincipal(identity, identity.GetRoles());
                context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }
    }
}