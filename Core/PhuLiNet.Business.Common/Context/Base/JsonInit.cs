using System.Collections.Generic;
using Technical.Utilities.Extensions;
using Newtonsoft.Json;
using PhuLiNet.Business.Common.Unit.Converters;

namespace PhuLiNet.Business.Common.Context.Base
{
    internal class JsonInit
    {
        public static void InitConverter()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = CustomConverters()
            };
        }

        public static void InitSerializer(JsonSerializer serializer)
        {
            serializer.Converters.AddRangeUnique(CustomConverters());
        }

        private static IList<JsonConverter> CustomConverters()
        {
            return new List<JsonConverter> {new WeekOfYearConverter(), new MonthOfYearConverter()};
        }
    }
}