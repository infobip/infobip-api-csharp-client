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
    ///     CallsBulkStatusResponse
    /// </summary>
    [DataContract(Name = "CallsBulkStatusResponse")]
    [JsonObject]
    public class CallsBulkStatusResponse : IEquatable<CallsBulkStatusResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkStatusResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsBulkStatusResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkStatusResponse" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID of the bulk..</param>
        /// <param name="status">status (required).</param>
        public CallsBulkStatusResponse(string bulkId = default, CallsBulkStatus status = default)
        {
            Status = status;
            BulkId = bulkId;
        }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "status", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("status")]
        public CallsBulkStatus Status { get; set; }

        /// <summary>
        ///     Unique ID of the bulk.
        /// </summary>
        /// <value>Unique ID of the bulk.</value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     Returns true if CallsBulkStatusResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsBulkStatusResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsBulkStatusResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    BulkId == input.BulkId ||
                    (BulkId != null &&
                     BulkId.Equals(input.BulkId))
                ) &&
                (
                    Status == input.Status ||
                    Status.Equals(input.Status)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsBulkStatusResponse {\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
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
            return Equals(input as CallsBulkStatusResponse);
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
                if (BulkId != null)
                    hashCode = hashCode * 59 + BulkId.GetHashCode();
                hashCode = hashCode * 59 + Status.GetHashCode();
                return hashCode;
            }
        }
    }
}