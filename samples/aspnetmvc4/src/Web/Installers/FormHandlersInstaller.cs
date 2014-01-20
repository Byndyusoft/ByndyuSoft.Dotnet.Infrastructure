namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using Mvc4Sample.Web.Application.Account.Forms.Handlers;

    [UsedImplicitly]
    public class FormHandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var formHandlers = Types.FromAssemblyContaining<SignInHandler>()
                                    .BasedOn(typeof (IFormHandler<>))
                                    .WithService.AllInterfaces()
                                    .LifestyleTransient();

            container.Register(formHandlers,
                               Component.For<IFormHandlerFactory>().AsFactory().LifestyleTransient());
        }
    }
}