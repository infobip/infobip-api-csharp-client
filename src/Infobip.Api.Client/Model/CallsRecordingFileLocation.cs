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
    ///     Location of recording file after processing..
    /// </summary>
    /// <value>Location of recording file after processing.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsRecordingFileLocation
    {
        /// <summary>
        ///     Enum Sftp for value: SFTP
        /// </summary>
        [EnumMember(Value = "SFTP")] Sftp = 1,

        /// <summary>
        ///     Enum Hosted for value: HOSTED
        /// </summary>
        [EnumMember(Value = "HOSTED")] Hosted = 2
    }
}