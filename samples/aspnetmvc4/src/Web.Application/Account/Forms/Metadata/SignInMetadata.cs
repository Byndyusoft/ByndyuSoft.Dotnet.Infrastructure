namespace Mvc4Sample.Web.Application.Account.Forms.Metadata
{
    using MvcExtensions;

    public class SignInMetadata : ModelMetadataConfiguration<SignIn>
    {
        public SignInMetadata()
        {
            Configure(x => x.Login)
                .DisplayName("Имя пользователя")
                .Required("Обязательное поле");

            Configure(x => x.Password)
                .DisplayName("Пароль")
                .Required("Обязательное поле")
                .AsPassword();

            Configure(x => x.RememberMe)
                .DisplayName("Запомнить меня");
        }
    }
}