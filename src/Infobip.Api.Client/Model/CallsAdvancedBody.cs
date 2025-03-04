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
    ///     CallsAdvancedBody
    /// </summary>
    [DataContract(Name = "CallsAdvancedBody")]
    [JsonObject]
    public class CallsAdvancedBody : IEquatable<CallsAdvancedBody>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAdvancedBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsAdvancedBody()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAdvancedBody" /> class.
        /// </summary>
        /// <param name="bulkId">The ID which uniquely identifies the request..</param>
        /// <param name="messages">Array of messages to be sent, one object per every message (required).</param>
        public CallsAdvancedBody(string bulkId = default, List<CallsAdvancedMessage> messages = default)
        {
            // to ensure "messages" is required (not null)
            Messages = messages ?? throw new ArgumentNullException("messages");
            BulkId = bulkId;
        }

        /// <summary>
        ///     The ID which uniquely identifies the request.
        /// </summary>
        /// <value>The ID which uniquely identifies the request.</value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     Array of messages to be sent, one object per every message
        /// </summary>
        /// <value>Array of messages to be sent, one object per every message</value>
        [DataMember(Name = "messages", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "messages", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("messages")]
        public List<CallsAdvancedMessage> Messages { get; set; }

        /// <summary>
        ///     Returns true if CallsAdvancedBody instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsAdvancedBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsAdvancedBody input)
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
            sb.Append("class CallsAdvancedBody {\n");
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
            return Equals(input as CallsAdvancedBody);
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