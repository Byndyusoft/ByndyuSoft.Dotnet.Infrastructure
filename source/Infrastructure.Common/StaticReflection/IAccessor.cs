using System;

namespace ByndyuSoft.Infrastructure.Common.StaticReflection
{
	public interface IAccessor<in TObject, TProperty> : ISetter<TObject, TProperty>, IGetter<TObject, TProperty>, ISetter, IGetter
	{
	}
}