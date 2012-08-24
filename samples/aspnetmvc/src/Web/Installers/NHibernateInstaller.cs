namespace MvcSample.Web.Installers
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Infrastructure.NHibernate;
    using JetBrains.Annotations;
    using NHibernate;
    using PerRequestSessionProvider = Infrastructure.NHibernate.PerRequestSessionProvider;

    [UsedImplicitly]
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<INHibernateInitializer>().ImplementedBy<NHibernateInitializer>(),
                Component.For<ISessionProvider>().ImplementedBy<PerRequestSessionProvider>().LifeStyle.PerWebRequest,
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (NHibernateRepository<>)).LifeStyle.PerWebRequest,
                Component.For<ILinqProvider>().ImplementedBy<NHibernateLinqProvider>().LifeStyle.PerWebRequest,
                Component.For<ISessionFactory>().UsingFactoryMethod(x => x.Resolve<INHibernateInitializer>()
                                                                         	.GetConfiguration()
                                                                         	.BuildSessionFactory())
                );
        }
    }
}