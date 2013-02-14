namespace ByndyuSoft.Infrastructure.NHibernate
{
    using System;
    using Domain;
    using FluentNHibernate.Automapping;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool AbstractClassIsLayerSupertype(Type type)
        {
            return true;
        }

        public override bool IsComponent(Type type)
        {
            return typeof (IEntityComponent).IsAssignableFrom(type);
        }

        public override bool IsDiscriminated(Type type)
        {
            return true;
        }

        public override bool ShouldMap(Type type)
        {
            return typeof (IEntity).IsAssignableFrom(type);
        }
    }
}