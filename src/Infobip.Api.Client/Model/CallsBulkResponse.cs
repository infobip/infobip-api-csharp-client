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
    ///     CallsBulkResponse
    /// </summary>
    [DataContract(Name = "CallsBulkResponse")]
    [JsonObject]
    public class CallsBulkResponse : IEquatable<CallsBulkResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsBulkResponse" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID of the bulk..</param>
        /// <param name="sendAt">Timestamp when bulk is scheduled..</param>
        public CallsBulkResponse(string bulkId = default, DateTimeOffset sendAt = default)
        {
            BulkId = bulkId;
            SendAt = sendAt;
        }

        /// <summary>
        ///     Unique ID of the bulk.
        /// </summary>
        /// <value>Unique ID of the bulk.</value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     Timestamp when bulk is scheduled.
        /// </summary>
        /// <value>Timestamp when bulk is scheduled.</value>
        [DataMember(Name = "sendAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sendAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sendAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset SendAt { get; set; }

        /// <summary>
        ///     Returns true if CallsBulkResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsBulkResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsBulkResponse input)
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
                    SendAt == input.SendAt ||
                    (SendAt != null &&
                     SendAt.Equals(input.SendAt))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsBulkResponse {\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
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
            return Equals(input as CallsBulkResponse);
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
                if (SendAt != null)
                    hashCode = hashCode * 59 + SendAt.GetHashCode();
                return hashCode;
            }
        }
    }
}