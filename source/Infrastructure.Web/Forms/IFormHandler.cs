namespace ByndyuSoft.Infrastructure.Web.Forms
{
    public interface IFormHandler<in TForm> where TForm:IForm
	{
		void Execute(TForm form); 
	}
}