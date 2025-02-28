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
    ///     CallRoutingPhoneEndpoint
    /// </summary>
    [DataContract(Name = "CallRoutingPhoneEndpoint")]
    [JsonObject]
    public class CallRoutingPhoneEndpoint : CallRoutingEndpoint, IEquatable<CallRoutingPhoneEndpoint>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingPhoneEndpoint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallRoutingPhoneEndpoint()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingPhoneEndpoint" /> class.
        /// </summary>
        /// <param name="phoneNumber">
        ///     Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format. Defaults to &#x60;to
        ///     &#x60; value used in inbound call..
        /// </param>
        /// <param name="type">type (required) (default to CallRoutingEndpointType.Phone).</param>
        public CallRoutingPhoneEndpoint(string phoneNumber = default,
            CallRoutingEndpointType type = CallRoutingEndpointType.Phone) : base(type)
        {
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        ///     Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format. Defaults to &#x60;to&#x60; value used in
        ///     inbound call.
        /// </summary>
        /// <value>
        ///     Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format. Defaults to &#x60;to&#x60; value used
        ///     in inbound call.
        /// </value>
        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "phoneNumber", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Returns true if CallRoutingPhoneEndpoint instances are equal
        /// </summary>
        /// <param name="input">Instance of CallRoutingPhoneEndpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallRoutingPhoneEndpoint input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       PhoneNumber == input.PhoneNumber ||
                       (PhoneNumber != null &&
                        PhoneNumber.Equals(input.PhoneNumber))
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallRoutingPhoneEndpoint {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
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
            return Equals(input as CallRoutingPhoneEndpoint);
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
                if (PhoneNumber != null)
                    hashCode = hashCode * 59 + PhoneNumber.GetHashCode();
                return hashCode;
            }
        }
    }
}