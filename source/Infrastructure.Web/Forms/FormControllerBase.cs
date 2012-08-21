namespace ByndyuSoft.Infrastructure.Web.Forms
{
    using System;
    using System.Web.Mvc;
    using ControllerBase = Web.ControllerBase;

    public class FormControllerBase : ControllerBase
    {
        private const string ModelStateKey = "ModelState";
        private readonly IFormHandlerFactory formHandlerFactory;

        protected FormControllerBase(IFormHandlerFactory formHandlerFactory)
        {
            this.formHandlerFactory = formHandlerFactory;
        }

        protected  ActionResult Form<TForm>(TForm form, ActionResult sucessResult) where TForm : IForm
        {
            return Form(form, () => sucessResult);
        }

        protected ActionResult Form<TForm>(TForm form, ActionResult sucessResult, ActionResult failResult) where TForm : IForm
        {
            return Form(form, () => sucessResult, () => failResult);
        }

        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult) where TForm : IForm
        {
            return Form(form, successResult, () => Redirect(Request.UrlReferrer.AbsoluteUri));
        }

        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult, Func<ActionResult> failResult) where TForm : IForm
        {
            if (ModelState.IsValid)
            {
                try
                {
                    formHandlerFactory.Create<TForm>().Execute(form);

                    return successResult();
                }
                catch (FormHandlerException fhe)
                {
                    var key = string.IsNullOrEmpty(fhe.Key) ? "form" : fhe.Key;
                    ModelState.AddModelError(key, fhe.Message);
                }
            }

            TempData[ModelStateKey] = ModelState;
            return failResult();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (TempData[ModelStateKey] != null && ModelState.Equals(TempData[ModelStateKey]) == false)
                ModelState.Merge((ModelStateDictionary) TempData[ModelStateKey]);

            base.OnActionExecuted(filterContext);
        }
    }
}