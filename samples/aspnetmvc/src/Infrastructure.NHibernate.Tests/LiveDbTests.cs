namespace MvcSample.Infrastructure.NHibernate.Tests
{
	using System;
	using System.Data.Common;
	using Domain.Entities;
	using JetBrains.Annotations;
	using Xunit;
	using global::NHibernate;
	using global::NHibernate.Cfg;
	using global::NHibernate.Engine;
	using global::NHibernate.Tool.hbm2ddl;

	[UsedImplicitly]
	public class LiveDbTests
	{
		[Fact]
		public void GenerateCreationScript()
		{
			Configuration configuration = CreateConfiguration();
			new SchemaExport(configuration)
				.SetDelimiter("\r\nGO\r\n")
				.Execute(true, false, false);
		}

		[Fact]
		public void AddUser()
		{
			Configuration configuration = CreateConfiguration();
			var factory = (ISessionFactoryImplementor) configuration.BuildSessionFactory();

			using (ISession session = factory.OpenSession())
			{
				var user = new User("name", "a@b.ru", "login");

				user.SetPassword("123");

				session.SaveOrUpdate(user);
			}
		}

		[Fact]
		public void GenerateMigrationScript()
		{
			Configuration configuration = CreateConfiguration();
			var factory = (ISessionFactoryImplementor) configuration.BuildSessionFactory();

			using (ISession session = factory.OpenSession())
			{
				string[] updateScripts = configuration.GenerateSchemaUpdateScript(factory.Dialect, new DatabaseMetadata((DbConnection) session.Connection, factory.Dialect));

				foreach (string updateScript in updateScripts)
				{
					Console.WriteLine(updateScript);
					Console.WriteLine(@"GO");
				}
			}
		}

		private static Configuration CreateConfiguration()
		{
			return new NHibernateInitializer().GetConfiguration();
		}
	}
}