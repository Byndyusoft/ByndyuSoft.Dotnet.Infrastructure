namespace Mvc4Sample.Domain.Entities
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using ByndyuSoft.Infrastructure.Common.Extensions;

    public sealed class Password
    {
        private static readonly int SaltLength = 15;
        private static readonly int HashLength = 512;
        private static readonly int PbkdfIterrationsCount = 3;

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
            string targerHash = HashPassword(oldPassword, Salt);

            bool areSame = true;
            for (int i = 0; i < targerHash.Length; i++)
                areSame &= (Hash[i] == targerHash[i]);

            return areSame;
        }

        private static string HashPassword(string password, string salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt.FromBase64().ToArray(), PbkdfIterrationsCount);
            return Convert.ToBase64String(pbkdf2.GetBytes(HashLength));
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