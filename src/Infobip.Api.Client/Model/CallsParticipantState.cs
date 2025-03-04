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
    ///     Participant state..
    /// </summary>
    /// <value>Participant state.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsParticipantState
    {
        /// <summary>
        ///     Enum Joining for value: JOINING
        /// </summary>
        [EnumMember(Value = "JOINING")] Joining = 1,

        /// <summary>
        ///     Enum Joined for value: JOINED
        /// </summary>
        [EnumMember(Value = "JOINED")] Joined = 2,

        /// <summary>
        ///     Enum Left for value: LEFT
        /// </summary>
        [EnumMember(Value = "LEFT")] Left = 3
    }
}