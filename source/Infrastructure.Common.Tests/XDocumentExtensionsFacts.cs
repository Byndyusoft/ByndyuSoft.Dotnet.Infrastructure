namespace Infrastructure.Common.Tests
{
    using System.Xml.Linq;
    using ByndyuSoft.Infrastructure.Common.Extensions;
    using NUnit.Framework;

    public class XDocumentExtensionsFacts
    {
        [Test]
        public void ToXml()
        {
            const string expected = @"<?xml version=""1.0"" encoding=""UTF-8""?><root />";
            var xdoc = new XDocument(new XElement("root"));
            string actual = xdoc.ToXml();
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}