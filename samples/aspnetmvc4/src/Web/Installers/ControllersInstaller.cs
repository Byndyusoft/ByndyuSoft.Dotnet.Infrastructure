namespace Web.Installers
{
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Mvc4Sample.Web.Application.Account;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<AccountController>()
                                      .BasedOn<IController>()
                                      .LifestyleTransient());
        }
    }
}