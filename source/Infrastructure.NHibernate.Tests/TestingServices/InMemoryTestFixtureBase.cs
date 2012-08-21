using System;
using FluentNHibernate;
using FluentNHibernate.Cfg;
//using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace ByndyuSoft.Infrastructure.NHibernate.Tests.TestingServices
{
	public abstract class InMemoryTestFixtureBase<TMapping, TConvention>
		where TMapping : class, IMappingProvider
		where TConvention : class
	{
		protected ISession Session;

		protected InMemoryTestFixtureBase()
		{
			//NHibernateProfiler.Initialize();

			TestFixtureSetup();
		}

		private void TestFixtureSetup()
		{
			Action<MappingConfiguration> mappings = (m => m.FluentMappings
															.AddFromAssemblyOf<TMapping>()
															.Conventions.AddFromAssemblyOf<TConvention>()
															.ExportTo(@"d:\"));

			Configuration configuration = new InMemorySQLiteInitializer(mappings)
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