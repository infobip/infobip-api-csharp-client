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
    ///     CallsBulkPhoneEndpoint
    /// </summary>
    [DataContract(Name = "CallsBulkPhoneEndpoint")]
    [JsonObject]
    public class CallsBulkPhoneEndpoint : CallsBulkEndpoint, IEquatable<CallsBulkPhoneEndpoint>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkPhoneEndpoint" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsBulkPhoneEndpoint()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkPhoneEndpoint" /> class.
        /// </summary>
        /// <param name="phoneNumber">Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format. (required).</param>
        /// <param name="type">type (default to CallsBulkEndpointType.Phone).</param>
        public CallsBulkPhoneEndpoint(string phoneNumber = default,
            CallsBulkEndpointType? type = CallsBulkEndpointType.Phone) : base(type)
        {
            // to ensure "phoneNumber" is required (not null)
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException("phoneNumber");
        }

        /// <summary>
        ///     Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format.
        /// </summary>
        /// <value>Phone number in the [E.164](https://en.wikipedia.org/wiki/E.164) format.</value>
        [DataMember(Name = "phoneNumber", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "phoneNumber", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Returns true if CallsBulkPhoneEndpoint instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsBulkPhoneEndpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsBulkPhoneEndpoint input)
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
            sb.Append("class CallsBulkPhoneEndpoint {\n");
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
            return Equals(input as CallsBulkPhoneEndpoint);
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