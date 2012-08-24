namespace ByndyuSoft.Infrastructure.Common.Extensions
{
	using System.Text;
	using System.Xml.Linq;

	/// <summary>
	///   Расшерения для XDocument
	/// </summary>
	public static class XDocumentExtensions
	{
		/// <summary>
		///   Преобразовать документ в XML-строку
		/// </summary>
		/// <param name="document"> </param>
		/// <returns> </returns>
		public static string ToXml(this XDocument document)
		{
			return ToXml(document, Encoding.UTF8, SaveOptions.DisableFormatting);
		}

		/// <summary>
		///   Преобразовать документ в XML-строку
		/// </summary>
		/// <param name="document"> Документ </param>
		/// <param name="encoding"> Кодировка документа </param>
		/// <returns> </returns>
		public static string ToXml(this XDocument document, Encoding encoding)
		{
			return ToXml(document, encoding, SaveOptions.DisableFormatting);
		}

		/// <summary>
		///   Преобразовать документ в XML-строку
		/// </summary>
		/// <param name="document"> Документ </param>
		/// <param name="options"> Опции сохранения </param>
		/// <returns> </returns>
		public static string ToXml(this XDocument document, SaveOptions options)
		{
			return ToXml(document, Encoding.UTF8, options);
		}

		/// <summary>
		///   Преобразовать документ в XML-строку
		/// </summary>
		/// <param name="document"> Документ </param>
		/// <param name="encoding"> Кодировка документа </param>
		/// <param name="options"> Опции сохранения </param>
		/// <returns> </returns>
		public static string ToXml(this XDocument document, Encoding encoding, SaveOptions options)
		{
			using (var writer = new EncodedStringWriter(encoding))
			{
				document.Save(writer, options);
				return writer.ToString();
			}
		}
	}
}