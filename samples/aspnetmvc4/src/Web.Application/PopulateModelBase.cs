namespace Mvc4Sample.Web.Application
{
    using System.Web.Mvc;

    public abstract class PopulateModelBase : ActionFilterAttribute
    {
        private readonly string viewDataKey;

        protected PopulateModelBase(string dataKey)
        {
            viewDataKey = dataKey;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData[viewDataKey] = GetSelectList(filterContext);
        }

        protected abstract SelectList GetSelectList(ActionExecutedContext filterContext);
    }
}