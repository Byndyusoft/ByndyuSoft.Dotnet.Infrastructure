namespace Mvc4Sample.Domain.Entities
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using ByndyuSoft.Infrastructure.Common.Extensions;

    public sealed class Password
    {
        private static readonly int SaltLength = 15;
        private static readonly HashAlgorithm hashAlgorithm = SHA512.Create();

        [Obsolete("Only for NHibernate")]
        protected Password()
        {
        }

        public Password(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public Password(string password)
        {
            Salt = MakeSalt();
            Hash = HashPassword(password, Salt);
        }

        public string Hash { get; private set; }

        public string Salt { get; private set; }

        public bool Check(string oldPassword)
        {
            return Hash == HashPassword(oldPassword, Salt);
        }

        private static string HashPassword(string password, string salt)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] passwordBytes = encoding.GetBytes(password)
                .Concat(salt.FromBase64())
                .ToArray();
            return hashAlgorithm.ComputeHash(passwordBytes).ToBase64();
        }

        private static string MakeSalt()
        {
            using (RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltLength];
                rngCryptoServiceProvider.GetBytes(salt);

                return salt.ToBase64();
            }
        }
    }
}