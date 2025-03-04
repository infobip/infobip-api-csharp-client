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

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallBulkResponse
    /// </summary>
    [DataContract(Name = "CallBulkResponse")]
    [JsonObject]
    public class CallBulkResponse : IEquatable<CallBulkResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallBulkResponse" /> class.
        /// </summary>
        /// <param name="bulkId">Unique ID of the bulk request..</param>
        /// <param name="calls">Bulk call list..</param>
        public CallBulkResponse(string bulkId = default, List<CallsBulkCall> calls = default)
        {
            BulkId = bulkId;
            Calls = calls;
        }

        /// <summary>
        ///     Unique ID of the bulk request.
        /// </summary>
        /// <value>Unique ID of the bulk request.</value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     Bulk call list.
        /// </summary>
        /// <value>Bulk call list.</value>
        [DataMember(Name = "calls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "calls", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("calls")]
        public List<CallsBulkCall> Calls { get; set; }

        /// <summary>
        ///     Returns true if CallBulkResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallBulkResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallBulkResponse input)
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
                    Calls == input.Calls ||
                    (Calls != null &&
                     input.Calls != null &&
                     Calls.SequenceEqual(input.Calls))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallBulkResponse {\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
            sb.Append("  Calls: ").Append(Calls).Append("\n");
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
            return Equals(input as CallBulkResponse);
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
                if (Calls != null)
                    hashCode = hashCode * 59 + Calls.GetHashCode();
                return hashCode;
            }
        }
    }
}