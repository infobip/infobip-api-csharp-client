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
    ///     Text language. Must be defined for correct pronunciation. For more details on available languages and voices, see
    ///     our
    ///     [documentation](https://www.infobip.com/docs/voice-and-video/outbound-calls#text-to-speech-voice-over-broadcast)..
    /// </summary>
    /// <value>
    ///     Text language. Must be defined for correct pronunciation. For more details on available languages and voices,
    ///     see our
    ///     [documentation](https://www.infobip.com/docs/voice-and-video/outbound-calls#text-to-speech-voice-over-broadcast).
    /// </value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallsLanguage
    {
        /// <summary>
        ///     Enum Ar for value: ar
        /// </summary>
        [EnumMember(Value = "ar")] Ar = 1,

        /// <summary>
        ///     Enum Bn for value: bn
        /// </summary>
        [EnumMember(Value = "bn")] Bn = 2,

        /// <summary>
        ///     Enum Bg for value: bg
        /// </summary>
        [EnumMember(Value = "bg")] Bg = 3,

        /// <summary>
        ///     Enum Ca for value: ca
        /// </summary>
        [EnumMember(Value = "ca")] Ca = 4,

        /// <summary>
        ///     Enum ZhCn for value: zh-cn
        /// </summary>
        [EnumMember(Value = "zh-cn")] ZhCn = 5,

        /// <summary>
        ///     Enum ZhTw for value: zh-tw
        /// </summary>
        [EnumMember(Value = "zh-tw")] ZhTw = 6,

        /// <summary>
        ///     Enum Hr for value: hr
        /// </summary>
        [EnumMember(Value = "hr")] Hr = 7,

        /// <summary>
        ///     Enum Cs for value: cs
        /// </summary>
        [EnumMember(Value = "cs")] Cs = 8,

        /// <summary>
        ///     Enum Da for value: da
        /// </summary>
        [EnumMember(Value = "da")] Da = 9,

        /// <summary>
        ///     Enum Nl for value: nl
        /// </summary>
        [EnumMember(Value = "nl")] Nl = 10,

        /// <summary>
        ///     Enum En for value: en
        /// </summary>
        [EnumMember(Value = "en")] En = 11,

        /// <summary>
        ///     Enum EnAu for value: en-au
        /// </summary>
        [EnumMember(Value = "en-au")] EnAu = 12,

        /// <summary>
        ///     Enum EnGb for value: en-gb
        /// </summary>
        [EnumMember(Value = "en-gb")] EnGb = 13,

        /// <summary>
        ///     Enum EnCa for value: en-ca
        /// </summary>
        [EnumMember(Value = "en-ca")] EnCa = 14,

        /// <summary>
        ///     Enum EnIn for value: en-in
        /// </summary>
        [EnumMember(Value = "en-in")] EnIn = 15,

        /// <summary>
        ///     Enum EnIe for value: en-ie
        /// </summary>
        [EnumMember(Value = "en-ie")] EnIe = 16,

        /// <summary>
        ///     Enum EnGbWls for value: en-gb-wls
        /// </summary>
        [EnumMember(Value = "en-gb-wls")] EnGbWls = 17,

        /// <summary>
        ///     Enum Epo for value: epo
        /// </summary>
        [EnumMember(Value = "epo")] Epo = 18,

        /// <summary>
        ///     Enum FilPh for value: fil-ph
        /// </summary>
        [EnumMember(Value = "fil-ph")] FilPh = 19,

        /// <summary>
        ///     Enum Fi for value: fi
        /// </summary>
        [EnumMember(Value = "fi")] Fi = 20,

        /// <summary>
        ///     Enum Fr for value: fr
        /// </summary>
        [EnumMember(Value = "fr")] Fr = 21,

        /// <summary>
        ///     Enum FrCa for value: fr-ca
        /// </summary>
        [EnumMember(Value = "fr-ca")] FrCa = 22,

        /// <summary>
        ///     Enum FrCh for value: fr-ch
        /// </summary>
        [EnumMember(Value = "fr-ch")] FrCh = 23,

        /// <summary>
        ///     Enum De for value: de
        /// </summary>
        [EnumMember(Value = "de")] De = 24,

        /// <summary>
        ///     Enum DeAt for value: de-at
        /// </summary>
        [EnumMember(Value = "de-at")] DeAt = 25,

        /// <summary>
        ///     Enum DeCh for value: de-ch
        /// </summary>
        [EnumMember(Value = "de-ch")] DeCh = 26,

        /// <summary>
        ///     Enum El for value: el
        /// </summary>
        [EnumMember(Value = "el")] El = 27,

        /// <summary>
        ///     Enum Gu for value: gu
        /// </summary>
        [EnumMember(Value = "gu")] Gu = 28,

        /// <summary>
        ///     Enum He for value: he
        /// </summary>
        [EnumMember(Value = "he")] He = 29,

        /// <summary>
        ///     Enum Hi for value: hi
        /// </summary>
        [EnumMember(Value = "hi")] Hi = 30,

        /// <summary>
        ///     Enum Hu for value: hu
        /// </summary>
        [EnumMember(Value = "hu")] Hu = 31,

        /// <summary>
        ///     Enum Is for value: is
        /// </summary>
        [EnumMember(Value = "is")] Is = 32,

        /// <summary>
        ///     Enum Id for value: id
        /// </summary>
        [EnumMember(Value = "id")] Id = 33,

        /// <summary>
        ///     Enum It for value: it
        /// </summary>
        [EnumMember(Value = "it")] It = 34,

        /// <summary>
        ///     Enum Ja for value: ja
        /// </summary>
        [EnumMember(Value = "ja")] Ja = 35,

        /// <summary>
        ///     Enum Kn for value: kn
        /// </summary>
        [EnumMember(Value = "kn")] Kn = 36,

        /// <summary>
        ///     Enum Ko for value: ko
        /// </summary>
        [EnumMember(Value = "ko")] Ko = 37,

        /// <summary>
        ///     Enum Ms for value: ms
        /// </summary>
        [EnumMember(Value = "ms")] Ms = 38,

        /// <summary>
        ///     Enum Ml for value: ml
        /// </summary>
        [EnumMember(Value = "ml")] Ml = 39,

        /// <summary>
        ///     Enum No for value: no
        /// </summary>
        [EnumMember(Value = "no")] No = 40,

        /// <summary>
        ///     Enum Pl for value: pl
        /// </summary>
        [EnumMember(Value = "pl")] Pl = 41,

        /// <summary>
        ///     Enum PtPt for value: pt-pt
        /// </summary>
        [EnumMember(Value = "pt-pt")] PtPt = 42,

        /// <summary>
        ///     Enum PtBr for value: pt-br
        /// </summary>
        [EnumMember(Value = "pt-br")] PtBr = 43,

        /// <summary>
        ///     Enum Ro for value: ro
        /// </summary>
        [EnumMember(Value = "ro")] Ro = 44,

        /// <summary>
        ///     Enum Ru for value: ru
        /// </summary>
        [EnumMember(Value = "ru")] Ru = 45,

        /// <summary>
        ///     Enum Sk for value: sk
        /// </summary>
        [EnumMember(Value = "sk")] Sk = 46,

        /// <summary>
        ///     Enum Sl for value: sl
        /// </summary>
        [EnumMember(Value = "sl")] Sl = 47,

        /// <summary>
        ///     Enum Es for value: es
        /// </summary>
        [EnumMember(Value = "es")] Es = 48,

        /// <summary>
        ///     Enum EsGl for value: es-gl
        /// </summary>
        [EnumMember(Value = "es-gl")] EsGl = 49,

        /// <summary>
        ///     Enum EsMx for value: es-mx
        /// </summary>
        [EnumMember(Value = "es-mx")] EsMx = 50,

        /// <summary>
        ///     Enum Sv for value: sv
        /// </summary>
        [EnumMember(Value = "sv")] Sv = 51,

        /// <summary>
        ///     Enum Ta for value: ta
        /// </summary>
        [EnumMember(Value = "ta")] Ta = 52,

        /// <summary>
        ///     Enum Te for value: te
        /// </summary>
        [EnumMember(Value = "te")] Te = 53,

        /// <summary>
        ///     Enum Th for value: th
        /// </summary>
        [EnumMember(Value = "th")] Th = 54,

        /// <summary>
        ///     Enum Tr for value: tr
        /// </summary>
        [EnumMember(Value = "tr")] Tr = 55,

        /// <summary>
        ///     Enum Uk for value: uk
        /// </summary>
        [EnumMember(Value = "uk")] Uk = 56,

        /// <summary>
        ///     Enum Vi for value: vi
        /// </summary>
        [EnumMember(Value = "vi")] Vi = 57,

        /// <summary>
        ///     Enum Wls for value: wls
        /// </summary>
        [EnumMember(Value = "wls")] Wls = 58,

        /// <summary>
        ///     Enum ArMa for value: ar-ma
        /// </summary>
        [EnumMember(Value = "ar-ma")] ArMa = 59,

        /// <summary>
        ///     Enum UrPk for value: ur-pk
        /// </summary>
        [EnumMember(Value = "ur-pk")] UrPk = 60,

        /// <summary>
        ///     Enum MrIn for value: mr-in
        /// </summary>
        [EnumMember(Value = "mr-in")] MrIn = 61
    }
}