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
    ///     The language code which message is written in used when sending text-to-speech messages. If not defined, it will
    ///     default to English (&#x60;en&#x60;)..
    /// </summary>
    /// <value>
    ///     The language code which message is written in used when sending text-to-speech messages. If not defined, it will
    ///     default to English (&#x60;en&#x60;).
    /// </value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TfaLanguage
    {
        /// <summary>
        ///     Enum En for value: en
        /// </summary>
        [EnumMember(Value = "en")] En = 1,

        /// <summary>
        ///     Enum Es for value: es
        /// </summary>
        [EnumMember(Value = "es")] Es = 2,

        /// <summary>
        ///     Enum Ca for value: ca
        /// </summary>
        [EnumMember(Value = "ca")] Ca = 3,

        /// <summary>
        ///     Enum Da for value: da
        /// </summary>
        [EnumMember(Value = "da")] Da = 4,

        /// <summary>
        ///     Enum Nl for value: nl
        /// </summary>
        [EnumMember(Value = "nl")] Nl = 5,

        /// <summary>
        ///     Enum Fr for value: fr
        /// </summary>
        [EnumMember(Value = "fr")] Fr = 6,

        /// <summary>
        ///     Enum De for value: de
        /// </summary>
        [EnumMember(Value = "de")] De = 7,

        /// <summary>
        ///     Enum It for value: it
        /// </summary>
        [EnumMember(Value = "it")] It = 8,

        /// <summary>
        ///     Enum Ja for value: ja
        /// </summary>
        [EnumMember(Value = "ja")] Ja = 9,

        /// <summary>
        ///     Enum Ko for value: ko
        /// </summary>
        [EnumMember(Value = "ko")] Ko = 10,

        /// <summary>
        ///     Enum No for value: no
        /// </summary>
        [EnumMember(Value = "no")] No = 11,

        /// <summary>
        ///     Enum Pl for value: pl
        /// </summary>
        [EnumMember(Value = "pl")] Pl = 12,

        /// <summary>
        ///     Enum Ru for value: ru
        /// </summary>
        [EnumMember(Value = "ru")] Ru = 13,

        /// <summary>
        ///     Enum Sv for value: sv
        /// </summary>
        [EnumMember(Value = "sv")] Sv = 14,

        /// <summary>
        ///     Enum Fi for value: fi
        /// </summary>
        [EnumMember(Value = "fi")] Fi = 15,

        /// <summary>
        ///     Enum Hr for value: hr
        /// </summary>
        [EnumMember(Value = "hr")] Hr = 16,

        /// <summary>
        ///     Enum Sl for value: sl
        /// </summary>
        [EnumMember(Value = "sl")] Sl = 17,

        /// <summary>
        ///     Enum Ro for value: ro
        /// </summary>
        [EnumMember(Value = "ro")] Ro = 18,

        /// <summary>
        ///     Enum PtPt for value: pt_pt
        /// </summary>
        [EnumMember(Value = "pt_pt")] PtPt = 19,

        /// <summary>
        ///     Enum PtBr for value: pt_br
        /// </summary>
        [EnumMember(Value = "pt_br")] PtBr = 20,

        /// <summary>
        ///     Enum ZhCn for value: zh_cn
        /// </summary>
        [EnumMember(Value = "zh_cn")] ZhCn = 21,

        /// <summary>
        ///     Enum ZhTw for value: zh_tw
        /// </summary>
        [EnumMember(Value = "zh_tw")] ZhTw = 22
    }
}