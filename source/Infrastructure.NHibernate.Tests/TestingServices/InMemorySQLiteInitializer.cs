using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace ByndyuSoft.Infrastructure.NHibernate.Tests.TestingServices
{
    public class InMemorySQLiteInitializer : INHibernateInitializer
    {
        private readonly Action<MappingConfiguration> mappings;

        public InMemorySQLiteInitializer(Action<MappingConfiguration> action)
        {
            mappings = action;
        }

        public Configuration GetConfiguration()
        {
            SQLiteConfiguration persistenceConfigurer = SQLiteConfiguration.Standard
                .Dialect<MySQLiteDialect>()
                .InMemory()
                .ShowSql();

            FluentConfiguration cfg = Fluently.Configure()
                .Database(persistenceConfigurer)
                .ExposeConfiguration(ExtendConfiguration)
                .ProxyFactoryFactory<DefaultProxyFactoryFactory>()
                .Mappings(mappings);
            return cfg.BuildConfiguration();
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