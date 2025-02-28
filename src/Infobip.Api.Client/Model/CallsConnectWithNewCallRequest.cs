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
    ///     CallsConnectWithNewCallRequest
    /// </summary>
    [DataContract(Name = "CallsConnectWithNewCallRequest")]
    [JsonObject]
    public class CallsConnectWithNewCallRequest : IEquatable<CallsConnectWithNewCallRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsConnectWithNewCallRequest" /> class.
        /// </summary>
        /// <param name="callRequest">callRequest.</param>
        /// <param name="connectOnEarlyMedia">
        ///     Indicates whether to connect calls on early media. Otherwise, the calls are connected
        ///     after being established. Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled. (default to
        ///     false).
        /// </param>
        /// <param name="ringbackGeneration">ringbackGeneration.</param>
        /// <param name="conferenceRequest">conferenceRequest.</param>
        public CallsConnectWithNewCallRequest(CallsActionCallRequest callRequest = default,
            bool connectOnEarlyMedia = false, RingbackGeneration ringbackGeneration = default,
            CallsActionConferenceRequest conferenceRequest = default)
        {
            CallRequest = callRequest;
            ConnectOnEarlyMedia = connectOnEarlyMedia;
            RingbackGeneration = ringbackGeneration;
            ConferenceRequest = conferenceRequest;
        }

        /// <summary>
        ///     Gets or Sets CallRequest
        /// </summary>
        [DataMember(Name = "callRequest", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "callRequest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("callRequest")]
        public CallsActionCallRequest CallRequest { get; set; }

        /// <summary>
        ///     Indicates whether to connect calls on early media. Otherwise, the calls are connected after being established.
        ///     Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled.
        /// </summary>
        /// <value>
        ///     Indicates whether to connect calls on early media. Otherwise, the calls are connected after being established.
        ///     Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled.
        /// </value>
        [DataMember(Name = "connectOnEarlyMedia", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "connectOnEarlyMedia", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("connectOnEarlyMedia")]
        public bool ConnectOnEarlyMedia { get; set; }

        /// <summary>
        ///     Gets or Sets RingbackGeneration
        /// </summary>
        [DataMember(Name = "ringbackGeneration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ringbackGeneration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("ringbackGeneration")]
        public RingbackGeneration RingbackGeneration { get; set; }

        /// <summary>
        ///     Gets or Sets ConferenceRequest
        /// </summary>
        [DataMember(Name = "conferenceRequest", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "conferenceRequest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("conferenceRequest")]
        public CallsActionConferenceRequest ConferenceRequest { get; set; }

        /// <summary>
        ///     Returns true if CallsConnectWithNewCallRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsConnectWithNewCallRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsConnectWithNewCallRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    CallRequest == input.CallRequest ||
                    (CallRequest != null &&
                     CallRequest.Equals(input.CallRequest))
                ) &&
                (
                    ConnectOnEarlyMedia == input.ConnectOnEarlyMedia ||
                    ConnectOnEarlyMedia.Equals(input.ConnectOnEarlyMedia)
                ) &&
                (
                    RingbackGeneration == input.RingbackGeneration ||
                    (RingbackGeneration != null &&
                     RingbackGeneration.Equals(input.RingbackGeneration))
                ) &&
                (
                    ConferenceRequest == input.ConferenceRequest ||
                    (ConferenceRequest != null &&
                     ConferenceRequest.Equals(input.ConferenceRequest))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsConnectWithNewCallRequest {\n");
            sb.Append("  CallRequest: ").Append(CallRequest).Append("\n");
            sb.Append("  ConnectOnEarlyMedia: ").Append(ConnectOnEarlyMedia).Append("\n");
            sb.Append("  RingbackGeneration: ").Append(RingbackGeneration).Append("\n");
            sb.Append("  ConferenceRequest: ").Append(ConferenceRequest).Append("\n");
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
            return Equals(input as CallsConnectWithNewCallRequest);
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
                if (CallRequest != null)
                    hashCode = hashCode * 59 + CallRequest.GetHashCode();
                hashCode = hashCode * 59 + ConnectOnEarlyMedia.GetHashCode();
                if (RingbackGeneration != null)
                    hashCode = hashCode * 59 + RingbackGeneration.GetHashCode();
                if (ConferenceRequest != null)
                    hashCode = hashCode * 59 + ConferenceRequest.GetHashCode();
                return hashCode;
            }
        }
    }
}