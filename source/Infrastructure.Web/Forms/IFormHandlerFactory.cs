namespace ByndyuSoft.Infrastructure.Web.Forms
{
    /// <summary>
    /// </summary>
    public interface IFormHandlerFactory
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TForm"></typeparam>
        /// <returns></returns>
        IFormHandler<TForm> Create<TForm>()
            where TForm : IForm;
    }
}