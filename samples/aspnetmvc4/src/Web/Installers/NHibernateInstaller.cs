namespace Web.Installers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using Mvc4Sample.Infrastructure.NHibernate;
    using NHibernate;
    using PerRequestSessionProvider = ByndyuSoft.Infrastructure.NHibernate.PerRequestSessionProvider;

    [UsedImplicitly]
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<INHibernateInitializer>().ImplementedBy<NHibernateInitializer>(),
                               Component.For<ISessionProvider>().ImplementedBy<PerRequestSessionProvider>().LifestylePerWebRequest(),
                               Component.For(typeof (IRepository<>)).ImplementedBy(typeof (NHibernateRepository<>)).LifestylePerWebRequest(),
                               Component.For<ILinqProvider>().ImplementedBy<NHibernateLinqProvider>().LifestylePerWebRequest(),
                               Component.For<ISessionFactory>().UsingFactoryMethod(x => x.Resolve<INHibernateInitializer>()
                                                                                         .GetConfiguration()
                                                                                         .BuildSessionFactory()));
        }
    }
}