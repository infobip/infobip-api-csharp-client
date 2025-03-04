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
    ///     Status group name that describes which category the status code belongs to, i.e.,
    ///     [PENDING](https://www.infobip.com/docs/essentials/response-status-and-error-codes#pending-general-status-codes),
    ///     [UNDELIVERABLE](https://www.infobip.com/docs/essentials/response-status-and-error-codes#undeliverable-general-status-codes),
    ///     [DELIVERED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#delivered-general-status-codes),
    ///     [EXPIRED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#expired-general-status-codes),
    ///     [REJECTED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#rejected-general-status-codes)..
    /// </summary>
    /// <value>
    ///     Status group name that describes which category the status code belongs to, i.e.,
    ///     [PENDING](https://www.infobip.com/docs/essentials/response-status-and-error-codes#pending-general-status-codes),
    ///     [UNDELIVERABLE](https://www.infobip.com/docs/essentials/response-status-and-error-codes#undeliverable-general-status-codes),
    ///     [DELIVERED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#delivered-general-status-codes),
    ///     [EXPIRED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#expired-general-status-codes),
    ///     [REJECTED](https://www.infobip.com/docs/essentials/response-status-and-error-codes#rejected-general-status-codes).
    /// </value>
    [JsonConverter(typeof(StringEnumConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageGeneralStatus
    {
        /// <summary>
        ///     Enum Accepted for value: ACCEPTED
        /// </summary>
        [EnumMember(Value = "ACCEPTED")] Accepted = 1,

        /// <summary>
        ///     Enum Pending for value: PENDING
        /// </summary>
        [EnumMember(Value = "PENDING")] Pending = 2,

        /// <summary>
        ///     Enum Undeliverable for value: UNDELIVERABLE
        /// </summary>
        [EnumMember(Value = "UNDELIVERABLE")] Undeliverable = 3,

        /// <summary>
        ///     Enum Delivered for value: DELIVERED
        /// </summary>
        [EnumMember(Value = "DELIVERED")] Delivered = 4,

        /// <summary>
        ///     Enum Expired for value: EXPIRED
        /// </summary>
        [EnumMember(Value = "EXPIRED")] Expired = 5,

        /// <summary>
        ///     Enum Rejected for value: REJECTED
        /// </summary>
        [EnumMember(Value = "REJECTED")] Rejected = 6
    }
}