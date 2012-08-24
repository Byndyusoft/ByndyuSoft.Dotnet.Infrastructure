namespace MvcSample.Web.Installers
{
	using Application.Account.Services;
	using Application.Account.Services.Impl;
	using Castle.MicroKernel.Registration;
	using Castle.MicroKernel.SubSystems.Configuration;
	using Castle.Windsor;

	public class AccountInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifeStyle.Transient,
			                   Component.For<IContextUserProvider>().ImplementedBy<ContextUserProvider>().LifeStyle.Transient);
		}
	}
}