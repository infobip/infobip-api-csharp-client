using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infobip.Api.Client
{
    public class JsonStringEnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private readonly Dictionary<string, T> _fromValue;
        private readonly Dictionary<T, string> _toValue;

        public JsonStringEnumMemberConverter()
        {
            _fromValue = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            _toValue = new Dictionary<T, string>();
            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var enumValue = (T)field.GetValue(null);
                var enumMemberAttr = field.GetCustomAttribute<EnumMemberAttribute>();
                var strValue = enumMemberAttr?.Value ?? field.Name;
                _fromValue[strValue] = enumValue;
                _toValue[enumValue] = strValue;
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var enumString = reader.GetString();
                if (_fromValue.TryGetValue(enumString, out var value))
                    return value;
                throw new JsonException($"Unknown value '{enumString}' for enum '{typeof(T).Name}'");
            }
            throw new JsonException($"Unexpected token parsing enum. Expected String, got {reader.TokenType}.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (_toValue.TryGetValue(value, out var stringValue))
                writer.WriteStringValue(stringValue);
            else
                writer.WriteStringValue(value.ToString());
        }
    }   
}