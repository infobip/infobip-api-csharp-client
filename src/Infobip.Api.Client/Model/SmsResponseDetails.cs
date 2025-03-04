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
    ///     An array of message objects of a single message or multiple messages sent under one bulk ID.
    /// </summary>
    [DataContract(Name = "SmsResponseDetails")]
    [JsonObject]
    public class SmsResponseDetails : IEquatable<SmsResponseDetails>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsResponseDetails" /> class.
        /// </summary>
        /// <param name="messageId">
        ///     Unique message ID. If not provided, it will be auto-generated and returned in the API
        ///     response..
        /// </param>
        /// <param name="status">status.</param>
        /// <param name="destination">The destination address of the message, i.e., its recipient..</param>
        /// <param name="details">details.</param>
        public SmsResponseDetails(string messageId = default, SmsMessageStatus status = default,
            string destination = default, SmsMessageResponseDetails details = default)
        {
            MessageId = messageId;
            Status = status;
            Destination = destination;
            Details = details;
        }

        /// <summary>
        ///     Unique message ID. If not provided, it will be auto-generated and returned in the API response.
        /// </summary>
        /// <value>Unique message ID. If not provided, it will be auto-generated and returned in the API response.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public SmsMessageStatus Status { get; set; }

        /// <summary>
        ///     The destination address of the message, i.e., its recipient.
        /// </summary>
        /// <value>The destination address of the message, i.e., its recipient.</value>
        [DataMember(Name = "destination", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "destination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        /// <summary>
        ///     Gets or Sets Details
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "details", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("details")]
        public SmsMessageResponseDetails Details { get; set; }

        /// <summary>
        ///     Returns true if SmsResponseDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsResponseDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsResponseDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                ) &&
                (
                    Status == input.Status ||
                    (Status != null &&
                     Status.Equals(input.Status))
                ) &&
                (
                    Destination == input.Destination ||
                    (Destination != null &&
                     Destination.Equals(input.Destination))
                ) &&
                (
                    Details == input.Details ||
                    (Details != null &&
                     Details.Equals(input.Details))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsResponseDetails {\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Destination: ").Append(Destination).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
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
            return Equals(input as SmsResponseDetails);
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
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (Destination != null)
                    hashCode = hashCode * 59 + Destination.GetHashCode();
                if (Details != null)
                    hashCode = hashCode * 59 + Details.GetHashCode();
                return hashCode;
            }
        }
    }
}