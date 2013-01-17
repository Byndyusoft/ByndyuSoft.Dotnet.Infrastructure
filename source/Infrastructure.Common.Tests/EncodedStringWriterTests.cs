namespace Infrastructure.Common.Tests
{
    using System.IO;
    using System.Text;
    using ByndyuSoft.Infrastructure.Common;
    using NUnit.Framework;

    public class EncodedStringWriterTests
    {
        [Test]
        public void Constructor()
        {
            TextWriter stringWriter = new EncodedStringWriter(Encoding.ASCII);
            Assert.AreEqual(Encoding.ASCII, stringWriter.Encoding);
        }
    }
}