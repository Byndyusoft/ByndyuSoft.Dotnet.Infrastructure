namespace ByndyuSoft.Infrastructure.Domain.Criterion
{
	/// <summary>
	/// Критерий для поиска по идентификатору
	/// </summary>
	public class FindById : ICriterion
	{
		internal FindById(int id)
		{
			Id = id;
		}

		/// <summary>
		/// Идентификатор доменной сущности
		/// </summary>
		public int Id { get; protected set; }
	}
}