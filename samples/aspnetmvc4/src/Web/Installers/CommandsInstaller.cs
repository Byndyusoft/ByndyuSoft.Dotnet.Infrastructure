namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain.Commands;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using Mvc4Sample.Web.Application.Infrastructure;

    [UsedImplicitly]
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            var commands = Types.FromAssemblyNamed(Config.CommandsAssemblyName)
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