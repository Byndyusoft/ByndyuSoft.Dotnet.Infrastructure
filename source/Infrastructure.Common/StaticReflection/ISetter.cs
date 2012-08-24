namespace ByndyuSoft.Infrastructure.Common.StaticReflection
{
	public interface ISetter<in TObject, in TProperty>
	{
		void Set(TObject @object, TProperty value);
	}

	public interface ISetter
	{
		void Set(object @object, object value);
	}
}