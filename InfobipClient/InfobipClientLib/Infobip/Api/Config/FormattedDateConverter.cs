using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infobip.Api.Config
{
    class FormattedDateConverter : DateTimeConverterBase
    {
        private static readonly JsonConverter JSON_CONVERTER = new IsoDateTimeConverter
        {
            DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.FFFK"
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType.Equals(typeof(FormattedDate)) || objectType.Equals(typeof(DateTimeOffset));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object parsedObject = JSON_CONVERTER.ReadJson(reader, objectType, existingValue, serializer);
            if (objectType.Equals(typeof(FormattedDate)))
            {
                return new FormattedDate((DateTime) parsedObject);
            }

            return parsedObject;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if(value.GetType().Equals(typeof(FormattedDate)))
            {
                value = ((FormattedDate)value).date;
            }
            
            JSON_CONVERTER.WriteJson(writer, value, serializer);
        }
    }
}
