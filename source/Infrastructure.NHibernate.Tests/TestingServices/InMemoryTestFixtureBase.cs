namespace Infrastructure.NHibernate.Tests.TestingServices
{
    using System.IO;
    using FluentNHibernate;
    using global::NHibernate;
    using global::NHibernate.Cfg;
    using global::NHibernate.Tool.hbm2ddl;

    public abstract class InMemoryTestFixtureBase<TMapping, TConvention>
        where TMapping : class, IMappingProvider
        where TConvention : class
    {
        protected ISession Session;

        protected InMemoryTestFixtureBase()
        {
            TestFixtureSetup();
        }

        private void TestFixtureSetup()
        {
            var configuration =
                new InMemorySQLiteInitializer(m => m.FluentMappings
                                                       .AddFromAssemblyOf<TMapping>()
                                                       .Conventions.AddFromAssemblyOf<TConvention>()
                                                       .ExportTo(Path.GetTempPath()))
                    .GetConfiguration();

            Session = configuration.BuildSessionFactory().OpenSession();

            BuildSchema(configuration, Session);
        }

        private static void BuildSchema(Configuration configuration, ISession session)
        {
            new SchemaExport(configuration).Execute(true, true, false, session.Connection, null);
        }
    }
}