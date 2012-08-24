namespace MvcSample.Infrastructure.NHibernate
{
	using ByndyuSoft.Infrastructure.Domain;
	using ByndyuSoft.Infrastructure.NHibernate;
	using ByndyuSoft.Infrastructure.NHibernate.Conventions;
	using Conventions;
	using Domain.Entities;
	using FluentNHibernate.Automapping;
	using FluentNHibernate.Cfg;
	using FluentNHibernate.Cfg.Db;
	using JetBrains.Annotations;
	using global::NHibernate.Cfg;
	using global::NHibernate.Context;

	[UsedImplicitly]
	public class NHibernateInitializer : INHibernateInitializer
	{
		public Configuration GetConfiguration()
		{
			MsSqlConfiguration config = MsSqlConfiguration.MsSql2008
				.ConnectionString(x => x.FromConnectionStringWithKey("Main"))
				.UseReflectionOptimizer()
				.AdoNetBatchSize(100);

			AutoPersistenceModel persistenceModel = AutoMap.AssemblyOf<User>(new AutomappingConfiguration())
				.IgnoreBase(typeof (TreeNode<>))
				.UseOverridesFromAssemblyOf<NHibernateInitializer>()
				.Conventions.AddFromAssemblyOf<EntityMapConvention>()
				.Conventions.Add<PropertyLengthConvention>();

			FluentConfiguration fluentConfiguration = Fluently.Configure()
				.CurrentSessionContext<ThreadStaticSessionContext>()
				.Database(config)
				.Mappings(x => x.AutoMappings.Add(persistenceModel))
				.ExposeConfiguration(Expose);

			return fluentConfiguration
				.BuildConfiguration();
		}

		private static void Expose(Configuration cfg)
		{
			cfg.SetProperty(Environment.GenerateStatistics, "true");
		}
	}
}