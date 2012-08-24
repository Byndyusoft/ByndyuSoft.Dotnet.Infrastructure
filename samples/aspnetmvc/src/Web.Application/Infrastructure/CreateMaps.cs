namespace MvcSample.Web.Application.Infrastructure
{
	using AutoMapper;
	using JetBrains.Annotations;
	using Map.Profiles;
	using MvcExtensions;

	[UsedImplicitly]
	public class CreateMaps : BootstrapperTask
	{
		public override TaskContinuation Execute()
		{
			Mapper.AddProfile<UserProfile>();

			return TaskContinuation.Continue;
		}
	}
}