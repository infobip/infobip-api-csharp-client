/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Message content.
    /// </summary>
    [JsonConverter(typeof(SmsMessageContentJsonConverter))]
    [DataContract(Name = "SmsMessageContent")]
    [JsonObject]
    public class SmsMessageContent : AbstractOpenAPISchema, IEquatable<SmsMessageContent>, IValidatableObject
    {
        private object _actualInstance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsMessageContent" /> class
        ///     with the <see cref="SmsBinaryContent" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of SmsBinaryContent.</param>
        public SmsMessageContent(SmsBinaryContent actualInstance)
        {
            IsNullable = false;
            SchemaType = "oneOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsMessageContent" /> class
        ///     with the <see cref="SmsTextContent" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of SmsTextContent.</param>
        public SmsMessageContent(SmsTextContent actualInstance)
        {
            IsNullable = false;
            SchemaType = "oneOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        ///     Gets or Sets ActualInstance
        /// </summary>
        public override object ActualInstance
        {
            get => _actualInstance;
            set
            {
                if (value.GetType() == typeof(SmsBinaryContent))
                    _actualInstance = value;
                else if (value.GetType() == typeof(SmsTextContent))
                    _actualInstance = value;
                else
                    throw new ArgumentException(
                        "Invalid instance found. Must be the following types: SmsBinaryContent, SmsTextContent");
            }
        }

        /// <summary>
        ///     Returns true if SmsMessageContent instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsMessageContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsMessageContent input)
        {
            if (input == null)
                return false;

            return ActualInstance.Equals(input.ActualInstance);
        }

        /// <summary>
        ///     To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }

        /// <summary>
        ///     Get the actual instance of `SmsBinaryContent`. If the actual instanct is not `SmsBinaryContent`,
        ///     the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of SmsBinaryContent</returns>
        public SmsBinaryContent GetSmsBinaryContent()
        {
            return (SmsBinaryContent)ActualInstance;
        }

        /// <summary>
        ///     Get the actual instance of `SmsTextContent`. If the actual instanct is not `SmsTextContent`,
        ///     the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of SmsTextContent</returns>
        public SmsTextContent GetSmsTextContent()
        {
            return (SmsTextContent)ActualInstance;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsMessageContent {\n");
            sb.Append("  ActualInstance: ").Append(ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(ActualInstance, SerializerSettings);
        }

        /// <summary>
        ///     Converts the JSON string into an instance of SmsMessageContent
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of SmsMessageContent</returns>
        public static SmsMessageContent FromJson(string jsonString)
        {
            SmsMessageContent newSmsMessageContent = null;

            if (jsonString == null)
                return newSmsMessageContent;

            var match = 0;
            var matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(SmsBinaryContent).GetProperty("AdditionalProperties") == null)
                    newSmsMessageContent =
                        new SmsMessageContent(
                            JsonConvert.DeserializeObject<SmsBinaryContent>(jsonString, SerializerSettings));

                else
                    newSmsMessageContent =
                        new SmsMessageContent(JsonConvert.DeserializeObject<SmsBinaryContent>(jsonString,
                            AdditionalPropertiesSerializerSettings));

                matchedTypes.Add("SmsBinaryContent");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                Debug.WriteLine("Failed to deserialize `{0}` into SmsBinaryContent: {1}", jsonString, exception);
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(SmsTextContent).GetProperty("AdditionalProperties") == null)
                    newSmsMessageContent =
                        new SmsMessageContent(
                            JsonConvert.DeserializeObject<SmsTextContent>(jsonString, SerializerSettings));

                else
                    newSmsMessageContent =
                        new SmsMessageContent(JsonConvert.DeserializeObject<SmsTextContent>(jsonString,
                            AdditionalPropertiesSerializerSettings));

                matchedTypes.Add("SmsTextContent");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                Debug.WriteLine("Failed to deserialize `{0}` into SmsTextContent: {1}", jsonString, exception);
            }

            if (match == 0)
                throw new InvalidDataException("The JSON string `" + jsonString +
                                               "` cannot be deserialized into any schema defined.");

            if (match > 1)
                throw new InvalidDataException("The JSON string `" + jsonString +
                                               "` incorrectly matches more than one schema (should be exactly one match): " +
                                               matchedTypes);

            // deserialization is considered successful at this point if no exception has been thrown.
            return newSmsMessageContent;
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as SmsMessageContent);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (ActualInstance != null)
                    hashCode = hashCode * 59 + ActualInstance.GetHashCode();
                return hashCode;
            }
        }
    }

    /// <summary>
    ///     Custom JSON converter for SmsMessageContent
    /// </summary>
    public class SmsMessageContentJsonConverter : JsonConverter
    {
        /// <summary>
        ///     To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)typeof(SmsMessageContent).GetMethod("ToJson").Invoke(value, null));
        }

        /// <summary>
        ///     To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Null)
                return SmsMessageContent.FromJson(JObject.Load(reader).ToString(Formatting.None));
            return null;
        }

        /// <summary>
        ///     Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}