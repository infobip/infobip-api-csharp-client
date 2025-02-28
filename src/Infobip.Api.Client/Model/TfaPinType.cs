/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */


using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Type of PIN code that will be generated and sent as part of 2FA message..
    /// </summary>
    /// <value>Type of PIN code that will be generated and sent as part of 2FA message.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TfaPinType
    {
        /// <summary>
        ///     Enum Numeric for value: NUMERIC
        /// </summary>
        [EnumMember(Value = "NUMERIC")] Numeric = 1,

        /// <summary>
        ///     Enum Alpha for value: ALPHA
        /// </summary>
        [EnumMember(Value = "ALPHA")] Alpha = 2,

        /// <summary>
        ///     Enum Hex for value: HEX
        /// </summary>
        [EnumMember(Value = "HEX")] Hex = 3,

        /// <summary>
        ///     Enum Alphanumeric for value: ALPHANUMERIC
        /// </summary>
        [EnumMember(Value = "ALPHANUMERIC")] Alphanumeric = 4
    }
}