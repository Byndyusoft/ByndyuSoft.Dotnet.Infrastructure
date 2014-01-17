namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Mvc4Sample.Infrastructure.OrmLite.Dtos;

    public class FormHandlerAndCommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            var formHandlers = Types.FromAssemblyNamed("Mvc4Sample.Web.Application")
                                    .BasedOn(typeof (IFormHandler<>))
                                    .WithService.AllInterfaces()
                                    .LifestyleTransient();

            container.Register(formHandlers,
                               Component.For<IFormHandlerFactory>().AsFactory().LifestyleTransient());

            var commands = Types.FromAssemblyContaining<UserDto>()
                    .BasedOn(typeof(ICommand<>))
                    .WithService
                    .AllInterfaces()
                    .LifestyleTransient();

            container.Register(commands,
                               Component.For<ICommandBuilder>().ImplementedBy<CommandBuilder>().LifestyleTransient(),
                               Component.For<ICommandFactory>().AsFactory().LifestyleTransient());
        }
    }
}