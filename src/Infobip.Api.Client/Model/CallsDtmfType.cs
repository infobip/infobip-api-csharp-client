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
    ///     DTMF type..
    /// </summary>
    /// <value>DTMF type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsDtmfType
    {
        /// <summary>
        ///     Enum RFC2833 for value: RFC2833
        /// </summary>
        [EnumMember(Value = "RFC2833")] RFC2833 = 1,

        /// <summary>
        ///     Enum Inband for value: INBAND
        /// </summary>
        [EnumMember(Value = "INBAND")] Inband = 2
    }
}