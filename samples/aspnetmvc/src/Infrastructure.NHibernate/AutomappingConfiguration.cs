namespace MvcSample.Infrastructure.NHibernate
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using ByndyuSoft.Infrastructure.Domain;
	using FluentNHibernate;
	using FluentNHibernate.Automapping;

	public class AutomappingConfiguration : DefaultAutomappingConfiguration
	{
		private readonly ICollection<Type> components = new HashSet<Type>
		                                                	{
		                                                	};

		private readonly ICollection<Type> types = new HashSet<Type>
		                                           	{
		                                           	};


		public override bool AbstractClassIsLayerSupertype(Type type)
		{
			return types.Contains(type) == false;
		}

		public override string GetComponentColumnPrefix(Member member)
		{
			return string.Format("{0}_", Regex.Replace(member.Name, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1_").ToUpper());
		}

		public override bool IsComponent(Type type)
		{
			return components.Contains(type);
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