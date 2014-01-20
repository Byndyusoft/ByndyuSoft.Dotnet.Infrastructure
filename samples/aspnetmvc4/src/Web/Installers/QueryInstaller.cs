namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using Mvc4Sample.Web.Application.Infrastructure;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.SqlServer;

    [UsedImplicitly]
    public class QueryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            OrmLiteConfig.DialectProvider = new SqlServerOrmLiteDialectProvider();

            var queries = Types.FromAssemblyNamed(Config.QueriesAssemblyName)
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