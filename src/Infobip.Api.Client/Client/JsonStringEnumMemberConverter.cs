using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infobip.Api.Client
{

    /// <summary>
    ///     System.Text.Json converter that serializes and deserializes enums using their <see cref="EnumMemberAttribute"/> values if present, else their names.
    ///     Ensures proper enum (de)serialization for API models where JSON uses string values defined by <see cref="EnumMemberAttribute"/>.
    /// </summary>
    /// <typeparam name="T">Enum type to convert.</typeparam>
    public class JsonStringEnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private readonly Dictionary<string, T> _fromValue;
        private readonly Dictionary<T, string> _toValue;

        /// <summary>
        ///     Initializes a new instance of <see cref="JsonStringEnumMemberConverter{T}"/>.
        ///     Builds internal mappings of enum values to their <see cref="EnumMemberAttribute"/> strings.
        /// </summary>
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

        /// <summary>
        ///     Reads and converts the JSON string value to the corresponding enum value,
        ///     interpreting <see cref="EnumMemberAttribute.Value"/> if present.
        /// </summary>
        /// <param name="reader">The reader to read from.</param>
        /// <param name="typeToConvert">The type being converted.</param>
        /// <param name="options">Serialization options to use.</param>
        /// <returns>The converted enum value.</returns>
        /// <exception cref="JsonException">Thrown if JSON token is not a string or cannot be mapped to enum.</exception>
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

        /// <summary>
        ///     Writes the enum value as a JSON string, preferring the <see cref="EnumMemberAttribute.Value"/> if present.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The enum value to write.</param>
        /// <param name="options">Serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (_toValue.TryGetValue(value, out var stringValue))
                writer.WriteStringValue(stringValue);
            else
                writer.WriteStringValue(value.ToString());
        }
    }   
}