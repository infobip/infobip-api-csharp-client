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
    ///     EmailSendResponse
    /// </summary>
    [DataContract(Name = "EmailSendResponse")]
    [JsonObject]
    public class EmailSendResponse : IEquatable<EmailSendResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailSendResponse" /> class.
        /// </summary>
        /// <param name="bulkId">The ID that uniquely identifies a list of message responses..</param>
        /// <param name="messages">List of message response details..</param>
        public EmailSendResponse(string bulkId = default, List<EmailResponseDetails> messages = default)
        {
            BulkId = bulkId;
            Messages = messages;
        }

        /// <summary>
        ///     The ID that uniquely identifies a list of message responses.
        /// </summary>
        /// <value>The ID that uniquely identifies a list of message responses.</value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     List of message response details.
        /// </summary>
        /// <value>List of message response details.</value>
        [DataMember(Name = "messages", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messages", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messages")]
        public List<EmailResponseDetails> Messages { get; set; }

        /// <summary>
        ///     Returns true if EmailSendResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailSendResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailSendResponse input)
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
                    Messages == input.Messages ||
                    (Messages != null &&
                     input.Messages != null &&
                     Messages.SequenceEqual(input.Messages))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailSendResponse {\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
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
            return Equals(input as EmailSendResponse);
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
                if (Messages != null)
                    hashCode = hashCode * 59 + Messages.GetHashCode();
                return hashCode;
            }
        }
    }
}