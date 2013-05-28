namespace Infrastructure.NHibernate.Tests.TestingServices
{
    using System;
    using ByndyuSoft.Infrastructure.NHibernate;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using global::NHibernate;
    using global::NHibernate.Bytecode;
    using global::NHibernate.Cfg;
    using global::NHibernate.Dialect;
    using global::NHibernate.Dialect.Function;

    public class InMemorySQLiteInitializer : INHibernateInitializer
    {
        private readonly Action<MappingConfiguration> _mappings;

        public InMemorySQLiteInitializer(Action<MappingConfiguration> action)
        {
            _mappings = action;
        }

        public Configuration GetConfiguration()
        {
            var persistenceConfigurer = SQLiteConfiguration.Standard
                .Dialect<MySQLiteDialect>()
                .InMemory()
                .ShowSql();

            var configuration = Fluently.Configure()
                .Database(persistenceConfigurer)
                .ExposeConfiguration(ExtendConfiguration)
                .ProxyFactoryFactory<DefaultProxyFactoryFactory>()
                .Mappings(_mappings);

            return configuration.BuildConfiguration();
        }

        private static void ExtendConfiguration(Configuration c)
        {
            c.SetProperty("generate_statistics", "true");
        }

        #region Nested type: MySQLiteDialect

        public class MySQLiteDialect : SQLiteDialect
        {
            public MySQLiteDialect()
            {
                RegisterFunction("sysdate", new SQLFunctionTemplate(
                                                NHibernateUtil.Date, "date('now')"));
            }
        }

        #endregion
    }
}