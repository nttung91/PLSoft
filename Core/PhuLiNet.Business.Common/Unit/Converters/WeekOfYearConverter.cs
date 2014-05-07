using System;
using Newtonsoft.Json;

namespace PhuLiNet.Business.Common.Unit.Converters
{
    public class WeekOfYearConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof (WeekOfYear));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return WeekOfYear.TryConvert(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((WeekOfYear) value).ToDateTime());
        }
    }
}