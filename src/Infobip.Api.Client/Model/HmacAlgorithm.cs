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
    ///     HMAC algorithm..
    /// </summary>
    /// <value>HMAC algorithm.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HmacAlgorithm
    {
        /// <summary>
        ///     Enum MD5 for value: HMAC_MD5
        /// </summary>
        [EnumMember(Value = "HMAC_MD5")] MD5 = 1,

        /// <summary>
        ///     Enum SHA1 for value: HMAC_SHA_1
        /// </summary>
        [EnumMember(Value = "HMAC_SHA_1")] SHA1 = 2,

        /// <summary>
        ///     Enum SHA224 for value: HMAC_SHA_224
        /// </summary>
        [EnumMember(Value = "HMAC_SHA_224")] SHA224 = 3,

        /// <summary>
        ///     Enum SHA256 for value: HMAC_SHA_256
        /// </summary>
        [EnumMember(Value = "HMAC_SHA_256")] SHA256 = 4,

        /// <summary>
        ///     Enum SHA384 for value: HMAC_SHA_384
        /// </summary>
        [EnumMember(Value = "HMAC_SHA_384")] SHA384 = 5,

        /// <summary>
        ///     Enum SHA512 for value: HMAC_SHA_512
        /// </summary>
        [EnumMember(Value = "HMAC_SHA_512")] SHA512 = 6
    }
}