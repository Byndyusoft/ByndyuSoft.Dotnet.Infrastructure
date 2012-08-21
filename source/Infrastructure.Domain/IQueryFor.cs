namespace ByndyuSoft.Infrastructure.Domain
{
	using JetBrains.Annotations;

	/// <summary>
	/// Интерфейс для задания критериев запроса
	/// </summary>
	/// <typeparam name="T">Тип возращаемого запросом значения</typeparam>
	public interface IQueryFor<out T>
	{
		/// <summary>
		/// Добавить критерии запроса
		/// </summary>
		/// <param name="criterion"></param>
		/// <typeparam name="TCriterion"></typeparam>
		/// <returns></returns>
		[CanBeNull]
		T With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;

		/// <summary>
		/// Добавить критерий для поиска доменной сущности по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор доменной сущности</param>
		/// <returns>Возвращает найденную доменную сущность, либо null</returns>
		[CanBeNull]
		T ById(int id);
	}
}