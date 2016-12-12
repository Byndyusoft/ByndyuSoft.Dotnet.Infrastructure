namespace MvcSample.Domain.Model.Tests
{
    using System;
    using System.Text;
    using Entities;
    using NUnit.Framework;

    [TestFixture]
    public class PasswordTest
    {
        [TestCase("Password123456123456", Result = true)]
        [TestCase("Password123456123456123456123456", Result = false)]
        [TestCase("Password123123456456123123456456", Result = false)]
        [TestCase("Password123456", Result = false)]
        [TestCase("Password1123456", Result = false)]
        public bool Check(string checkedPassword)
        {
            var password = new Password("Password123456123456");
            return password.Check(checkedPassword);
        }

        private static string GetRandomString(int length)
        {
            var random = new Random();
            var result = new StringBuilder();

            const string chars =
                "~!@#№$%^&*()\":{}'[];/?.,/\\*-+ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщьыъэюя";

            for (var i = 0; i < length; i++)
                result.Append(chars[random.Next(chars.Length)]);

            return result.ToString();
        }

        [Test]
        public void HashLengthShouldBeConst()
        {
            var passwordSample = new Password("привет");

            for (var i = 1; i < 10000; i++)
            {
                var checkedPassword = new Password(GetRandomString(i));
                Assert.AreEqual(passwordSample.Hash.Length, checkedPassword.Hash.Length);
            }
        }
    }
}
