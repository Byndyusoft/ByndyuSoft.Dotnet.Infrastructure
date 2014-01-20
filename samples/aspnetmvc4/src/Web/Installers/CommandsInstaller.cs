namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Mvc4Sample.Infrastructure.OrmLite.Dtos;

    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            var commands = Types.FromAssemblyContaining<UserDto>()
                                .BasedOn(typeof (ICommand<>))
                                .WithService
                                .AllInterfaces()
                                .LifestyleTransient();

            container.Register(commands,
                               Component.For<ICommandBuilder>().ImplementedBy<CommandBuilder>().LifestyleTransient(),
                               Component.For<ICommandFactory>().AsFactory().LifestyleTransient());
        }
    }
}