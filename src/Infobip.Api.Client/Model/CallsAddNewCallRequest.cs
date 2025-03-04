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
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallsAddNewCallRequest
    /// </summary>
    [DataContract(Name = "CallsAddNewCallRequest")]
    [JsonObject]
    public class CallsAddNewCallRequest : IEquatable<CallsAddNewCallRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAddNewCallRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsAddNewCallRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAddNewCallRequest" /> class.
        /// </summary>
        /// <param name="callRequest">callRequest (required).</param>
        /// <param name="connectOnEarlyMedia">
        ///     Indicates whether to connect a new call on early media. Otherwise, the call will be
        ///     connected after being established. Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled.
        ///     (default to false).
        /// </param>
        /// <param name="ringbackGeneration">ringbackGeneration.</param>
        public CallsAddNewCallRequest(CallsActionCallRequest callRequest = default, bool connectOnEarlyMedia = false,
            RingbackGeneration ringbackGeneration = default)
        {
            // to ensure "callRequest" is required (not null)
            CallRequest = callRequest ?? throw new ArgumentNullException("callRequest");
            ConnectOnEarlyMedia = connectOnEarlyMedia;
            RingbackGeneration = ringbackGeneration;
        }

        /// <summary>
        ///     Gets or Sets CallRequest
        /// </summary>
        [DataMember(Name = "callRequest", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "callRequest", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("callRequest")]
        public CallsActionCallRequest CallRequest { get; set; }

        /// <summary>
        ///     Indicates whether to connect a new call on early media. Otherwise, the call will be connected after being
        ///     established. Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled.
        /// </summary>
        /// <value>
        ///     Indicates whether to connect a new call on early media. Otherwise, the call will be connected after being
        ///     established. Cannot be &#x60;true&#x60; when &#x60;ringbackGeneration&#x60; is enabled.
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
        ///     Returns true if CallsAddNewCallRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsAddNewCallRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsAddNewCallRequest input)
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
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsAddNewCallRequest {\n");
            sb.Append("  CallRequest: ").Append(CallRequest).Append("\n");
            sb.Append("  ConnectOnEarlyMedia: ").Append(ConnectOnEarlyMedia).Append("\n");
            sb.Append("  RingbackGeneration: ").Append(RingbackGeneration).Append("\n");
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
            return Equals(input as CallsAddNewCallRequest);
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
                return hashCode;
            }
        }
    }
}