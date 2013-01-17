namespace MvcSample.Web.Application.Account.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Criteria;
    using Domain.Entities;
    using Services;

    public class SignInHandler : IFormHandler<SignIn>
    {
        private readonly IQueryBuilder query;
        private readonly IAuthenticationService service;

        public SignInHandler(IAuthenticationService service, IQueryBuilder query)
        {
            this.service = service;
            this.query = query;
        }

        public virtual void Execute(SignIn command)
        {
            User user = query.For<User>()
                .With(new FindByLogin {Login = command.Login});

            if (user == null || user.Password.Check(command.Password) == false)
                throw new FormHandlerException("Неверный имя пользователя или пароль");

            service.SignIn(user, command.RememberMe);
        }
    }
}