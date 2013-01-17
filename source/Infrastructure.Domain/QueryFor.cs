namespace ByndyuSoft.Infrastructure.Domain
{
	using Criterion;

	/// <summary>
	/// Стандартная реализация <see cref="IQueryFor{T}"/>
	/// </summary>
	/// <typeparam name="TResult">Результат возвращаемый запросом</typeparam>
	public class QueryFor<TResult> : IQueryFor<TResult>
	{
		private readonly IQueryFactory factory;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="factory"></param>
		public QueryFor(IQueryFactory factory)
		{
			this.factory = factory;
		}

		public TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
		{
			return factory.Create<TCriterion, TResult>().Ask(criterion);
		}

		public TResult All()
		{
			return factory.Create<AllEntities, TResult>().Ask(new AllEntities());
		}

		public TResult ById(int id)
		{
			return factory.Create<FindById, TResult>().Ask(new FindById(id));
		}
	}
}