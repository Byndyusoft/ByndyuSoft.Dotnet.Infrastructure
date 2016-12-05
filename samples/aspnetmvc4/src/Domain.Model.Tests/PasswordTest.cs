namespace Mvc4Sample.Domain.Model.Tests
{
    using Entities;
    using NUnit.Framework;

    [TestFixture]
    public class PasswordTest
    {
        Password _password;

        [SetUp]
        public void SetUp()
        {
            _password = new Password("Password123456123456");
        }

        [TestCase("Password123456123456", Result = true)]
        [TestCase("Password123456123456123456123456", Result = false)]
        [TestCase("Password123123456456123123456456", Result = false)]
        [TestCase("Password123456", Result = false)]
        [TestCase("Password1123456", Result = false)]
        public bool Check(string checkedPassword)
        {
            return _password.Check(checkedPassword);
        }
    }
}