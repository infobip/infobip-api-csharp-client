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
    ///     Strategy for SIP trunk host selection..
    /// </summary>
    /// <value>Strategy for SIP trunk host selection.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsSelectionStrategy
    {
        /// <summary>
        ///     Enum Failover for value: FAILOVER
        /// </summary>
        [EnumMember(Value = "FAILOVER")] Failover = 1,

        /// <summary>
        ///     Enum RoundRobin for value: ROUND_ROBIN
        /// </summary>
        [EnumMember(Value = "ROUND_ROBIN")] RoundRobin = 2
    }
}