namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class QueryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var queries = Types.FromAssemblyNamed("Mvc4Sample.Infrastructure.NHibernate")
                               .BasedOn(typeof (IQuery<,>))
                               .WithService
                               .AllInterfaces()
                               .LifestyleTransient();

            container.Register(queries,
                               Component.For<IQueryBuilder>().AsFactory().LifestyleTransient(),
                               Component.For<IQueryFactory>().AsFactory().LifestyleTransient(),
                               Component.For(typeof (IQueryFor<>)).ImplementedBy(typeof (QueryFor<>)).LifestyleTransient());
        }
    }
}