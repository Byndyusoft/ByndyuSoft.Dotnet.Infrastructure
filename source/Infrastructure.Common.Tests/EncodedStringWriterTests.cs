namespace Infrastructure.Common.Tests
{
	using System.IO;
	using System.Text;
	using ByndyuSoft.Infrastructure.Common;
	using Xunit;

	public class EncodedStringWriterTests
	{
		[Fact]
		public void Constructor()
		{
			TextWriter stringWriter = new EncodedStringWriter(Encoding.ASCII);
			Assert.Equal(Encoding.ASCII, stringWriter.Encoding);
		}
	}
}