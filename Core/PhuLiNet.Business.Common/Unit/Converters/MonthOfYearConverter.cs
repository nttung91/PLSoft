using System;
using Newtonsoft.Json;

namespace PhuLiNet.Business.Common.Unit.Converters
{
    public class MonthOfYearConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof (MonthOfYear));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return MonthOfYear.TryConvert(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((MonthOfYear) value).ToDateTime());
        }
    }
}