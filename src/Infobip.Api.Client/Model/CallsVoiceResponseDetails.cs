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
    ///     Array of sent messages, one object per every message.
    /// </summary>
    [DataContract(Name = "CallsVoiceResponseDetails")]
    [JsonObject]
    public class CallsVoiceResponseDetails : IEquatable<CallsVoiceResponseDetails>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsVoiceResponseDetails" /> class.
        /// </summary>
        /// <param name="to">The message destination address..</param>
        /// <param name="status">status.</param>
        /// <param name="messageId">The ID that uniquely identifies the message sent..</param>
        public CallsVoiceResponseDetails(string to = default, CallsSingleMessageStatus status = default,
            string messageId = default)
        {
            To = to;
            Status = status;
            MessageId = messageId;
        }

        /// <summary>
        ///     The message destination address.
        /// </summary>
        /// <value>The message destination address.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public CallsSingleMessageStatus Status { get; set; }

        /// <summary>
        ///     The ID that uniquely identifies the message sent.
        /// </summary>
        /// <value>The ID that uniquely identifies the message sent.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Returns true if CallsVoiceResponseDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsVoiceResponseDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsVoiceResponseDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
                ) &&
                (
                    Status == input.Status ||
                    (Status != null &&
                     Status.Equals(input.Status))
                ) &&
                (
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsVoiceResponseDetails {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
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
            return Equals(input as CallsVoiceResponseDetails);
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
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                return hashCode;
            }
        }
    }
}