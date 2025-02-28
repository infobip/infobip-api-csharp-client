/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */


using System;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     TfaStartAuthenticationResponse
    /// </summary>
    [DataContract(Name = "TfaStartAuthenticationResponse")]
    [JsonObject]
    public class TfaStartAuthenticationResponse : IEquatable<TfaStartAuthenticationResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaStartAuthenticationResponse" /> class.
        /// </summary>
        /// <param name="callStatus">Call status, e.g. &#x60;PENDING_ACCEPTED&#x60;..</param>
        /// <param name="ncStatus">
        ///     Status of sent [Number Lookup](https://www.infobip.com/docs/number-lookup). Number Lookup status
        ///     can have one of the following values: &#x60;NC_DESTINATION_UNKNOWN&#x60;, &#x60;NC_DESTINATION_REACHABLE&#x60;,
        ///     &#x60;NC_DESTINATION_NOT_REACHABLE&#x60;, &#x60;NC_NOT_CONFIGURED&#x60;. Contact your Account Manager, if you get
        ///     the &#x60;NC_NOT_CONFIGURED&#x60; status. SMS will not be sent only if Number Lookup status is &#x60;
        ///     NC_NOT_REACHABLE&#x60;..
        /// </param>
        /// <param name="pinId">Sent PIN code ID..</param>
        /// <param name="smsStatus">
        ///     Sent SMS status. Can have one of the following values: &#x60;MESSAGE_SENT&#x60;, &#x60;
        ///     MESSAGE_NOT_SENT&#x60;..
        /// </param>
        /// <param name="to">Phone number to which the 2FA message will be sent. Example: &#x60;41793026727&#x60;..</param>
        public TfaStartAuthenticationResponse(string callStatus = default, string ncStatus = default,
            string pinId = default, string smsStatus = default, string to = default)
        {
            CallStatus = callStatus;
            NcStatus = ncStatus;
            PinId = pinId;
            SmsStatus = smsStatus;
            To = to;
        }

        /// <summary>
        ///     Call status, e.g. &#x60;PENDING_ACCEPTED&#x60;.
        /// </summary>
        /// <value>Call status, e.g. &#x60;PENDING_ACCEPTED&#x60;.</value>
        [DataMember(Name = "callStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "callStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("callStatus")]
        public string CallStatus { get; set; }

        /// <summary>
        ///     Status of sent [Number Lookup](https://www.infobip.com/docs/number-lookup). Number Lookup status can have one of
        ///     the following values: &#x60;NC_DESTINATION_UNKNOWN&#x60;, &#x60;NC_DESTINATION_REACHABLE&#x60;, &#x60;
        ///     NC_DESTINATION_NOT_REACHABLE&#x60;, &#x60;NC_NOT_CONFIGURED&#x60;. Contact your Account Manager, if you get the
        ///     &#x60;NC_NOT_CONFIGURED&#x60; status. SMS will not be sent only if Number Lookup status is &#x60;NC_NOT_REACHABLE
        ///     &#x60;.
        /// </summary>
        /// <value>
        ///     Status of sent [Number Lookup](https://www.infobip.com/docs/number-lookup). Number Lookup status can have one of
        ///     the following values: &#x60;NC_DESTINATION_UNKNOWN&#x60;, &#x60;NC_DESTINATION_REACHABLE&#x60;, &#x60;
        ///     NC_DESTINATION_NOT_REACHABLE&#x60;, &#x60;NC_NOT_CONFIGURED&#x60;. Contact your Account Manager, if you get the
        ///     &#x60;NC_NOT_CONFIGURED&#x60; status. SMS will not be sent only if Number Lookup status is &#x60;NC_NOT_REACHABLE
        ///     &#x60;.
        /// </value>
        [DataMember(Name = "ncStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ncStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("ncStatus")]
        public string NcStatus { get; set; }

        /// <summary>
        ///     Sent PIN code ID.
        /// </summary>
        /// <value>Sent PIN code ID.</value>
        [DataMember(Name = "pinId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pinId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("pinId")]
        public string PinId { get; set; }

        /// <summary>
        ///     Sent SMS status. Can have one of the following values: &#x60;MESSAGE_SENT&#x60;, &#x60;MESSAGE_NOT_SENT&#x60;.
        /// </summary>
        /// <value>Sent SMS status. Can have one of the following values: &#x60;MESSAGE_SENT&#x60;, &#x60;MESSAGE_NOT_SENT&#x60;.</value>
        [DataMember(Name = "smsStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "smsStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("smsStatus")]
        public string SmsStatus { get; set; }

        /// <summary>
        ///     Phone number to which the 2FA message will be sent. Example: &#x60;41793026727&#x60;.
        /// </summary>
        /// <value>Phone number to which the 2FA message will be sent. Example: &#x60;41793026727&#x60;.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     Returns true if TfaStartAuthenticationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaStartAuthenticationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaStartAuthenticationResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    CallStatus == input.CallStatus ||
                    (CallStatus != null &&
                     CallStatus.Equals(input.CallStatus))
                ) &&
                (
                    NcStatus == input.NcStatus ||
                    (NcStatus != null &&
                     NcStatus.Equals(input.NcStatus))
                ) &&
                (
                    PinId == input.PinId ||
                    (PinId != null &&
                     PinId.Equals(input.PinId))
                ) &&
                (
                    SmsStatus == input.SmsStatus ||
                    (SmsStatus != null &&
                     SmsStatus.Equals(input.SmsStatus))
                ) &&
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaStartAuthenticationResponse {\n");
            sb.Append("  CallStatus: ").Append(CallStatus).Append("\n");
            sb.Append("  NcStatus: ").Append(NcStatus).Append("\n");
            sb.Append("  PinId: ").Append(PinId).Append("\n");
            sb.Append("  SmsStatus: ").Append(SmsStatus).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as TfaStartAuthenticationResponse);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (CallStatus != null)
                    hashCode = hashCode * 59 + CallStatus.GetHashCode();
                if (NcStatus != null)
                    hashCode = hashCode * 59 + NcStatus.GetHashCode();
                if (PinId != null)
                    hashCode = hashCode * 59 + PinId.GetHashCode();
                if (SmsStatus != null)
                    hashCode = hashCode * 59 + SmsStatus.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                return hashCode;
            }
        }
    }
}