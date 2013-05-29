namespace ByndyuSoft.Infrastructure.Web.Forms
{
    using System;
    using System.Web.Mvc;
    using JetBrains.Annotations;
    using ControllerBase = ControllerBase;

    /// <summary>
    /// </summary>
    public abstract class FormControllerBase : ControllerBase
    {
        private const string ModelStateKey = "ModelState";

        /// <summary>
        /// </summary>
        [UsedImplicitly]
        public IFormHandlerFactory FormHandlerFactory { get; private set; }

        [PublicAPI]
        protected ActionResult Form<TForm>(TForm form, ActionResult sucessResult) where TForm : IForm
        {
            return Form(form, () => sucessResult);
        }

        [PublicAPI]
        protected ActionResult Form<TForm>(TForm form, ActionResult sucessResult, ActionResult failResult)
            where TForm : IForm
        {
            return Form(form, () => sucessResult, () => failResult);
        }

        [PublicAPI]
        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult) where TForm : IForm
        {
            return Form(form, successResult, () => Redirect(Request.UrlReferrer.AbsoluteUri));
        }

        [PublicAPI]
        protected ActionResult Form<TForm>(TForm form, Func<ActionResult> successResult, Func<ActionResult> failResult)
            where TForm : IForm
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FormHandlerFactory.Create<TForm>().Execute(form);

                    return successResult();
                }
                catch (FormHandlerException fhe)
                {
                    string key = string.IsNullOrEmpty(fhe.Key) ? "form" : fhe.Key;
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