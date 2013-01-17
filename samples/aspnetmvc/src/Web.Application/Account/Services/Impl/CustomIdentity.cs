namespace MvcSample.Web.Application.Account.Services.Impl
{
    using System;
    using System.Security.Principal;

    [Serializable]
    public class CustomIdentity : MarshalByRefObject, IIdentity
    {
        private readonly AccountEntry accountEntry;

        public CustomIdentity(AccountEntry accountEntry, string name)
        {
            Name = name;
            this.accountEntry = accountEntry;
        }

        public int Id
        {
            get { return accountEntry.Id; }
        }

        public RoleType RoleType
        {
            get { return accountEntry.RoleType; }
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return Id > 0; }
        }

        public string Name { get; private set; }

        public string[] GetRoles()
        {
            return new[] {RoleType.ToString()};
        }
    }
}