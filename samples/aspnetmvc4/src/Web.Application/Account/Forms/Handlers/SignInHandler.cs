namespace Mvc4Sample.Web.Application.Account.Forms.Handlers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.Web.Forms;
    using Criteria;
    using Domain.Entities;
    using Services;

    public class SignInHandler : IFormHandler<SignIn>
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly IAuthenticationService _authenticationService;

        public SignInHandler(IAuthenticationService authenticationService, IQueryBuilder queryBuilder)
        {
            _authenticationService = authenticationService;
            _queryBuilder = queryBuilder;
        }

        public virtual void Execute(SignIn command)
        {
            User user = _queryBuilder.For<User>()
                                     .With(new FindByLogin {Login = command.Login});

            if (user == null || user.Password.Check(command.Password) == false)
                throw new FormHandlerException("Неверный имя пользователя или пароль");

            _authenticationService.SignIn(user, command.RememberMe);
        }
    }
}