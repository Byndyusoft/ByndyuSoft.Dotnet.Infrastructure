namespace MvcSample.Web.Application.Infrastructure
{
    using Account.Profiles;
    using AutoMapper;
    using JetBrains.Annotations;
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