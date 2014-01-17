namespace Mvc4Sample.Domain.Entities
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class User : IEntity
    {
        [Obsolete("Only for NH", true)]
        public User()
        {
        }

        public User([NotNull] string name, [NotNull] string email, [NotNull] string login)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            if (string.IsNullOrEmpty(login)) throw new ArgumentNullException("login");

            Name = name;
            Email = email;
            Login = login;
        }

        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Login { get; protected set; }

        [NotNull]
        public virtual string Email { get; protected set; }

        [NotNull]
        public virtual Password Password { get; protected set; }

        public virtual int Id { get; set; }

        public virtual void SetPassword([NotNull] string password)
        {
            Password = new Password(password);
        }
    }
}