namespace MvcSample.Web
{
	using Application.Infrastructure;
	using MvcExtensions;
	using MvcExtensions.Windsor;

	public class MvcApplication : WindsorMvcApplication
	{
		public MvcApplication()
		{
			Bootstrapper.BootstrapperTasks
				.Include<RegisterControllers>()
				.Include<RegisterModelMetadata>()
				.Include<RegisterActionInvokers>()
				.Include<RegisterRoutes>()
				.Include<CreateMaps>();
		}
	}
}