namespace ByndyuSoft.Infrastructure.Web
{
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// </summary>
    public static class JsonObjectExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="textWriter"></param>
        public static void ToJson(this object value, TextWriter textWriter)
        {
            var settings = new JsonSerializerSettings
                               {
                                   NullValueHandling = NullValueHandling.Ignore,
                                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                               };
            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new IsoDateTimeConverter {DateTimeFormat = "d"});
            JsonSerializer.Create(settings).Serialize(textWriter, value);
        }
    }
}