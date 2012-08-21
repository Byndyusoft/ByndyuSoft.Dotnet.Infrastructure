using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ByndyuSoft.Infrastructure.Common.StaticReflection
{
	internal class Accessor<TObject, TProperty> : IAccessor<TObject, TProperty>
	{
		private readonly Func<TObject, TProperty> getter;
		private readonly Action<TObject, TProperty> setter;

		public Accessor(Func<TObject, TProperty> getter, Action<TObject, TProperty> setter)
		{
			this.getter = getter;
			this.setter = setter;
		}

		public void Set(TObject @object, TProperty value)
		{
			setter(@object, value);
		}

		public TProperty Get(TObject @object)
		{
			return getter(@object);
		}

		public void Set(object @object, object value)
		{
			setter((TObject)@object, (TProperty)value);
		}

		public object Get(object @object)
		{
			return getter((TObject)@object);
		}
	}

	public static class Accessor
	{
		public static AccessorBuilder<TObject> For<TObject>()
		{
			return new AccessorBuilder<TObject>();
		}

		#region Nested type: AccessorBuilder

		public class AccessorBuilder<TObject>
		{
			public IAccessor<TObject, TProperty> From<TProperty>(Expression<Func<TObject, TProperty>> expression)
			{
				var memberExpression = expression.Body as MemberExpression;
				if (memberExpression == null)
				{
					throw new NotSupportedException();
				}

				ParameterExpression param1 = Expression.Parameter(typeof (TObject), "object");
				ParameterExpression param2 = Expression.Parameter(typeof (TProperty), "value");

				Action<TObject, TProperty> setter = MakeSetter<TProperty>(param1, param2, memberExpression.Member);

				return new Accessor<TObject, TProperty>(expression.Compile(), setter);
			}

			private static Action<TObject, TProperty> MakeSetter<TProperty>(ParameterExpression param1,
			                                                                ParameterExpression param2,
			                                                                MemberInfo memberInfo)
			{
				Expression<Action<TObject, TProperty>> exp = Expression.Lambda<Action<TObject, TProperty>>(
					Expression.Assign(Expression.MakeMemberAccess(param1, memberInfo), param2),
					param1,
					param2);

				return exp.Compile();
			}

			public IAccessor<TObject, TProperty> From<TProperty>(string memberName)
			{
				MemberInfo[] member = typeof (TObject).GetMember(memberName,
				                                                 BindingFlags.Instance |
				                                                 BindingFlags.Public |
				                                                 BindingFlags.NonPublic);

				MemberInfo memberInfo = member.FirstOrDefault();
				if (memberInfo == null)
				{
					throw new NotSupportedException();
				}

				ParameterExpression param1 = Expression.Parameter(typeof (TObject), "object");
				ParameterExpression param2 = Expression.Parameter(typeof (TProperty), "value");

				Func<TObject, TProperty> getter = MakeGetter<TProperty>(memberInfo, param1);

				Action<TObject, TProperty> setter = MakeSetter<TProperty>(param1, param2, memberInfo);

				return new Accessor<TObject, TProperty>(getter, setter);
			}

			private static Func<TObject, TProperty> MakeGetter<TProperty>(MemberInfo memberInfo,
			                                                              ParameterExpression param1)
			{
				Expression<Func<TObject, TProperty>> expression = Expression.Lambda<Func<TObject, TProperty>>(
					Expression.MakeMemberAccess(param1, memberInfo), param1);

				return expression.Compile();
			}
		}

		#endregion
	}
}