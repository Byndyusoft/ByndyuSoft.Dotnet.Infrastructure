namespace MvcSample.Infrastructure.NHibernate.Overrides
{
	using Domain.Entities;
	using FluentNHibernate.Automapping;
	using FluentNHibernate.Automapping.Alterations;

	public class UserOverride : IAutoMappingOverride<User>
	{
		public void Override(AutoMapping<User> mapping)
		{
			mapping.Table("USERS");
		}
	}
}