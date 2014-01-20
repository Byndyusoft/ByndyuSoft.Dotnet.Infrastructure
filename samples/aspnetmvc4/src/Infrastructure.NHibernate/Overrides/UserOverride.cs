namespace Mvc4Sample.Infrastructure.NHibernate.Overrides
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Mvc4Sample.Domain.Entities;

    public class UserOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Table("USERS");
        }
    }
}