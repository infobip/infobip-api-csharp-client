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
    ///     CallsBulkRequest
    /// </summary>
    [DataContract(Name = "CallsBulkRequest")]
    [JsonObject]
    public class CallsBulkRequest : IEquatable<CallsBulkRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsBulkRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkRequest" /> class.
        /// </summary>
        /// <param name="sendAt">Rescheduled timestamp of the bulk. (required).</param>
        public CallsBulkRequest(DateTimeOffset sendAt = default)
        {
            SendAt = sendAt;
        }

        /// <summary>
        ///     Rescheduled timestamp of the bulk.
        /// </summary>
        /// <value>Rescheduled timestamp of the bulk.</value>
        [DataMember(Name = "sendAt", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "sendAt", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("sendAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset SendAt { get; set; }

        /// <summary>
        ///     Returns true if CallsBulkRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsBulkRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsBulkRequest input)
        {
            if (input == null)
                return false;

            return
                SendAt == input.SendAt ||
                (SendAt != null &&
                 SendAt.Equals(input.SendAt));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsBulkRequest {\n");
            sb.Append("  SendAt: ").Append(SendAt).Append("\n");
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
            return Equals(input as CallsBulkRequest);
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
                if (SendAt != null)
                    hashCode = hashCode * 59 + SendAt.GetHashCode();
                return hashCode;
            }
        }
    }
}