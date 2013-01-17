namespace MvcSample.Web.Application.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class CheckFormsAndHandlersIntegration
    {
        [Test]
        public void AllFormsShouldHaveOneAndOnlyOneHandler()
        {
            Type[] types = Assembly.Load("MvcSample.Web.Application")
                .GetTypes();

            Type[] forms = types
                .Where(x => x.GetInterface("IForm") != null)
                .Where(x => x.IsPublic && x.IsAbstract == false)
                .ToArray();

            Type[] handlers = types
                .Where(x => x.GetInterface("IFormHandler`1") != null)
                .Where(x => x.IsPublic && x.IsAbstract == false)
                .ToArray();

            foreach (Type form in forms)
            {
                Type[] concreteHandlers = handlers
                    .Where(x => x.GetInterface("IFormHandler`1").GetGenericArguments().First() == form)
                    .ToArray();
                Console.WriteLine("{0}", form);
                foreach (Type concreteHandler in concreteHandlers)
                    Console.WriteLine("\thandled by {0}", concreteHandler);
                Assert.AreEqual(concreteHandlers.Length, 1);
            }
        }
    }
}