namespace ByndyuSoft.Infrastructure.Common
{
	using System.IO;
	using System.Text;

	/// <summary>
	/// <see cref="StringWriter"/>
	/// </summary>
	public class EncodedStringWriter : StringWriter
	{
		private readonly Encoding _encoding;

	    /// <summary>
        ///     Creates new instance of <see cref="EncodedStringWriter"/> with specified encoding.
	    /// </summary>
	    /// <param name="encoding">Encoding for newly created instance of <see cref="EncodedStringWriter"/>.</param>
	    public EncodedStringWriter(Encoding encoding)
		{
			_encoding = encoding;
		}

	    /// <summary>
	    ///     Gets the <see cref="T:System.Text.Encoding" /> in which the output is written.
	    /// </summary>
	    /// <returns>
	    ///     The Encoding in which the output is written.
	    /// </returns>
	    /// <filterpriority>1</filterpriority>
	    public override Encoding Encoding
		{
			get { return _encoding; }
		}
	}
}