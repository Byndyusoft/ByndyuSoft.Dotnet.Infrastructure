using System;
using System.IO;
using System.Text;

namespace ByndyuSoft.Infrastructure.Common
{
	/// <summary>
	/// <see cref="StringWriter"/>
	/// </summary>
	public class EncodedStringWriter : StringWriter
	{
		private readonly Encoding encoding;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="encoding"></param>
		public EncodedStringWriter(Encoding encoding)
		{
			this.encoding = encoding;
		}

		/// <summary>
		/// Gets the <see cref="T:System.Text.Encoding"/> in which the output is written.
		/// </summary>
		/// <returns>
		/// The Encoding in which the output is written.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public override Encoding Encoding
		{
			get { return encoding; }
		}
	}
}