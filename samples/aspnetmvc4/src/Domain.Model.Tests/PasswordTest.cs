namespace Mvc4Sample.Domain.Model.Tests
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
            Password password = new Password("Password123456123456");
            return password.Check(checkedPassword);
        }

        [Test]
        public void HashLengthShouldBeConst()
        {
            Password passwordSample = new Password("привет");
            
            for (int i = 1; i < 10000; i++)
            {
                Password checkedPassword = new Password(GetRandomString(i));
                Assert.AreEqual(passwordSample.Hash.Length, checkedPassword.Hash.Length);
            }
        }

        private static string GetRandomString(int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder();

            const string chars = "~!@#№$%^&*()\":{}'[];/?.,/\\*-+ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯабвгдеёжзийклмнопрстуфхцчшщьыъэюя";

            for (int i = 0; i < length; i++)
                result.Append(chars[random.Next(chars.Length)]);

            return result.ToString();
        }
    }
}
