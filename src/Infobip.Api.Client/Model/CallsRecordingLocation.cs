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
    ///     Defines CallsRecordingLocation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsRecordingLocation
    {
        /// <summary>
        ///     Enum SaoPaulo for value: SAO_PAULO
        /// </summary>
        [EnumMember(Value = "SAO_PAULO")] SaoPaulo = 1,

        /// <summary>
        ///     Enum Bogota for value: BOGOTA
        /// </summary>
        [EnumMember(Value = "BOGOTA")] Bogota = 2,

        /// <summary>
        ///     Enum Frankfurt for value: FRANKFURT
        /// </summary>
        [EnumMember(Value = "FRANKFURT")] Frankfurt = 3,

        /// <summary>
        ///     Enum Johannesburg for value: JOHANNESBURG
        /// </summary>
        [EnumMember(Value = "JOHANNESBURG")] Johannesburg = 4,

        /// <summary>
        ///     Enum JOHANNESBURG1 for value: JOHANNESBURG_1
        /// </summary>
        [EnumMember(Value = "JOHANNESBURG_1")] JOHANNESBURG1 = 5,

        /// <summary>
        ///     Enum NewYork for value: NEW_YORK
        /// </summary>
        [EnumMember(Value = "NEW_YORK")] NewYork = 6,

        /// <summary>
        ///     Enum Portland for value: PORTLAND
        /// </summary>
        [EnumMember(Value = "PORTLAND")] Portland = 7,

        /// <summary>
        ///     Enum Moscow for value: MOSCOW
        /// </summary>
        [EnumMember(Value = "MOSCOW")] Moscow = 8,

        /// <summary>
        ///     Enum Singapore for value: SINGAPORE
        /// </summary>
        [EnumMember(Value = "SINGAPORE")] Singapore = 9,

        /// <summary>
        ///     Enum Istanbul for value: ISTANBUL
        /// </summary>
        [EnumMember(Value = "ISTANBUL")] Istanbul = 10,

        /// <summary>
        ///     Enum KualaLumpur for value: KUALA_LUMPUR
        /// </summary>
        [EnumMember(Value = "KUALA_LUMPUR")] KualaLumpur = 11,

        /// <summary>
        ///     Enum Jakarta for value: JAKARTA
        /// </summary>
        [EnumMember(Value = "JAKARTA")] Jakarta = 12,

        /// <summary>
        ///     Enum Mumbai for value: MUMBAI
        /// </summary>
        [EnumMember(Value = "MUMBAI")] Mumbai = 13,

        /// <summary>
        ///     Enum HONGKONG1 for value: HONG_KONG_1
        /// </summary>
        [EnumMember(Value = "HONG_KONG_1")] HONGKONG1 = 14,

        /// <summary>
        ///     Enum HongKong for value: HONG_KONG
        /// </summary>
        [EnumMember(Value = "HONG_KONG")] HongKong = 15,

        /// <summary>
        ///     Enum Riyadh for value: RIYADH
        /// </summary>
        [EnumMember(Value = "RIYADH")] Riyadh = 16,

        /// <summary>
        ///     Enum Chennai for value: CHENNAI
        /// </summary>
        [EnumMember(Value = "CHENNAI")] Chennai = 17
    }
}