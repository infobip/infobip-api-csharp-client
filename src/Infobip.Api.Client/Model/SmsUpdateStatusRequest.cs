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
    ///     SmsUpdateStatusRequest
    /// </summary>
    [DataContract(Name = "SmsUpdateStatusRequest")]
    [JsonObject]
    public class SmsUpdateStatusRequest : IEquatable<SmsUpdateStatusRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsUpdateStatusRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SmsUpdateStatusRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsUpdateStatusRequest" /> class.
        /// </summary>
        /// <param name="status">status (required).</param>
        public SmsUpdateStatusRequest(SmsBulkStatus status = default)
        {
            Status = status;
        }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "status", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("status")]
        public SmsBulkStatus Status { get; set; }

        /// <summary>
        ///     Returns true if SmsUpdateStatusRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsUpdateStatusRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsUpdateStatusRequest input)
        {
            if (input == null)
                return false;

            return
                Status == input.Status ||
                Status.Equals(input.Status);
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsUpdateStatusRequest {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return Equals(input as SmsUpdateStatusRequest);
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
                hashCode = hashCode * 59 + Status.GetHashCode();
                return hashCode;
            }
        }
    }
}