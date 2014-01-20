namespace Mvc4Sample.Web.Application.Infrastructure
{
    using System.Web.Mvc;

    public abstract class PopulateModelBase : ActionFilterAttribute
    {
        private readonly string _viewDataKey;

        protected PopulateModelBase(string dataKey)
        {
            _viewDataKey = dataKey;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData[_viewDataKey] = GetSelectList(filterContext);
        }

        protected abstract SelectList GetSelectList(ActionExecutedContext filterContext);
    }
}