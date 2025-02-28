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
using JsonSubTypes;
using Newtonsoft.Json;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Criteria type.
    /// </summary>
    [DataContract(Name = "CallRoutingCriteria")]
    [JsonObject]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(CallRoutingPhoneCriteria), "PHONE")]
    [JsonSubtypes.KnownSubType(typeof(CallRoutingSipCriteria), "SIP")]
    [JsonSubtypes.KnownSubType(typeof(CallRoutingWebRTCCriteria), "WEBRTC")]
    public class CallRoutingCriteria : IEquatable<CallRoutingCriteria>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingCriteria" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallRoutingCriteria()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingCriteria" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        public CallRoutingCriteria(CallRoutingCriteriaType type = default)
        {
            Type = type;
        }

        /// <summary>
        ///     Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "type", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("type")]
        public CallRoutingCriteriaType Type { get; set; }

        /// <summary>
        ///     Returns true if CallRoutingCriteria instances are equal
        /// </summary>
        /// <param name="input">Instance of CallRoutingCriteria to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallRoutingCriteria input)
        {
            if (input == null)
                return false;

            return
                Type == input.Type ||
                Type.Equals(input.Type);
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallRoutingCriteria {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return Equals(input as CallRoutingCriteria);
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
                hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }
    }
}