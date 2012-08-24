namespace MvcSample.Web.Installers
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using ByndyuSoft.Infrastructure.Domain;

    public class QueryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var queries = AllTypes.FromAssemblyNamed("MvcSample.Infrastructure.NHibernate")
                .BasedOn(typeof (IQuery<,>))
                .WithService.AllInterfaces()
                .Configure(x => x.LifeStyle.Transient);

            container.Register(
                queries,
                Component.For<IQueryBuilder>().AsFactory().LifeStyle.Transient,
                Component.For<IQueryFactory>().AsFactory().LifeStyle.Transient,
                Component.For(typeof (IQueryFor<>)).ImplementedBy(typeof (QueryFor<>)));
        }
    }
}