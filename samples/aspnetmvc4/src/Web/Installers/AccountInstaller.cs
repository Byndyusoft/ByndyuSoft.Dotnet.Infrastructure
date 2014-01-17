namespace Web.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Mvc4Sample.Web.Application.Account.Services;
    using Mvc4Sample.Web.Application.Account.Services.Impl;

    public class AccountInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifestyleTransient(),
                               Component.For<IContextUserProvider>().ImplementedBy<ContextUserProvider>().LifestyleTransient());
        }
    }
}