namespace Infrastructure.Common.Tests
{
	using System;
	using System.Globalization;
	using System.Xml.Linq;
	using ByndyuSoft.Infrastructure.Common.Extensions;
	using Xunit;

	public class XDocumentExtensionsFacts
	{
		[Fact]
		public void ToXml()
		{
			const string expected = @"<?xml version=""1.0"" encoding=""UTF-8""?><root />";
			var xdoc = new XDocument(new XElement("root"));
			string actual = xdoc.ToXml();
			Assert.Equal(expected, actual, StringComparer.Create(CultureInfo.CurrentCulture, true));
		}
	}
}