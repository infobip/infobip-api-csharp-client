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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallRoutingSipEndpoint
    /// </summary>
    [DataContract(Name = "CallRoutingSipEndpoint")]
    [JsonObject]
    public class CallRoutingSipEndpoint : CallRoutingEndpoint, IEquatable<CallRoutingSipEndpoint>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingSipEndpoint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallRoutingSipEndpoint()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingSipEndpoint" /> class.
        /// </summary>
        /// <param name="username">Username sent to a selected SIP trunk. When not defined, Infobip DID number is used instead..</param>
        /// <param name="sipTrunkId">Unique identifier of a SIP trunk. (required).</param>
        /// <param name="customHeaders">
        ///     Custom headers. Only headers starting with &#x60;X-Client-&#x60; prefix will be
        ///     propagated..
        /// </param>
        /// <param name="type">type (required) (default to CallRoutingEndpointType.Sip).</param>
        public CallRoutingSipEndpoint(string username = default, string sipTrunkId = default,
            Dictionary<string, string> customHeaders = default,
            CallRoutingEndpointType type = CallRoutingEndpointType.Sip) : base(type)
        {
            // to ensure "sipTrunkId" is required (not null)
            SipTrunkId = sipTrunkId ?? throw new ArgumentNullException("sipTrunkId");
            Username = username;
            CustomHeaders = customHeaders;
        }

        /// <summary>
        ///     Username sent to a selected SIP trunk. When not defined, Infobip DID number is used instead.
        /// </summary>
        /// <value>Username sent to a selected SIP trunk. When not defined, Infobip DID number is used instead.</value>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "username", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        ///     Unique identifier of a SIP trunk.
        /// </summary>
        /// <value>Unique identifier of a SIP trunk.</value>
        [DataMember(Name = "sipTrunkId", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "sipTrunkId", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("sipTrunkId")]
        public string SipTrunkId { get; set; }

        /// <summary>
        ///     Custom headers. Only headers starting with &#x60;X-Client-&#x60; prefix will be propagated.
        /// </summary>
        /// <value>Custom headers. Only headers starting with &#x60;X-Client-&#x60; prefix will be propagated.</value>
        [DataMember(Name = "customHeaders", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customHeaders", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("customHeaders")]
        public Dictionary<string, string> CustomHeaders { get; set; }

        /// <summary>
        ///     Returns true if CallRoutingSipEndpoint instances are equal
        /// </summary>
        /// <param name="input">Instance of CallRoutingSipEndpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallRoutingSipEndpoint input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       Username == input.Username ||
                       (Username != null &&
                        Username.Equals(input.Username))
                   ) && base.Equals(input) &&
                   (
                       SipTrunkId == input.SipTrunkId ||
                       (SipTrunkId != null &&
                        SipTrunkId.Equals(input.SipTrunkId))
                   ) && base.Equals(input) &&
                   (
                       CustomHeaders == input.CustomHeaders ||
                       (CustomHeaders != null &&
                        input.CustomHeaders != null &&
                        CustomHeaders.SequenceEqual(input.CustomHeaders))
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallRoutingSipEndpoint {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  SipTrunkId: ").Append(SipTrunkId).Append("\n");
            sb.Append("  CustomHeaders: ").Append(CustomHeaders).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return Equals(input as CallRoutingSipEndpoint);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = base.GetHashCode();
                if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                if (SipTrunkId != null)
                    hashCode = hashCode * 59 + SipTrunkId.GetHashCode();
                if (CustomHeaders != null)
                    hashCode = hashCode * 59 + CustomHeaders.GetHashCode();
                return hashCode;
            }
        }
    }
}