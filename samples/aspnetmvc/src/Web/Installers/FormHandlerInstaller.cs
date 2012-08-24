namespace MvcSample.Web.Installers
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using ByndyuSoft.Infrastructure.Web.Forms;

    public class FormHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var formHandlers = AllTypes.FromAssemblyNamed("MvcSample.Web.Application")
                .BasedOn(typeof (IFormHandler<>))
                .WithService.AllInterfaces()
                .Configure(x => x.LifeStyle.Transient);

            container.Register(
                formHandlers,
                Component.For<IFormHandlerFactory>().AsFactory().LifeStyle.Transient);
        }
    }
}