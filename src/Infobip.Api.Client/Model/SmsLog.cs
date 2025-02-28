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
    ///     An array of message log results, one object per each message log entry.
    /// </summary>
    [DataContract(Name = "SmsLog")]
    [JsonObject]
    public class SmsLog : IEquatable<SmsLog>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsLog" /> class.
        /// </summary>
        /// <param name="sender">The sender ID which can be alphanumeric or numeric..</param>
        /// <param name="destination">Message destination address..</param>
        /// <param name="bulkId">
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages
        ///     via a single API request..
        /// </param>
        /// <param name="messageId">Unique message ID for which a log is requested..</param>
        /// <param name="sentAt">
        ///     Date and time when the message was sent. Has the following format: yyyy-MM-dd&#39;T&#39;
        ///     HH:mm:ss.SSSZ..
        /// </param>
        /// <param name="doneAt">
        ///     Date and time when the Infobip services finished processing the message (i.e., delivered to the
        ///     destination, network, etc.). Has the following format: yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ..
        /// </param>
        /// <param name="messageCount">The number of messages content was split to..</param>
        /// <param name="price">price.</param>
        /// <param name="status">status.</param>
        /// <param name="error">error.</param>
        /// <param name="platform">platform.</param>
        /// <param name="content">content.</param>
        /// <param name="campaignReferenceId">ID of a campaign that was sent in the message..</param>
        /// <param name="mccMnc">Mobile country and network codes..</param>
        public SmsLog(string sender = default, string destination = default, string bulkId = default,
            string messageId = default, DateTimeOffset sentAt = default, DateTimeOffset doneAt = default,
            int messageCount = default, MessagePrice price = default, SmsMessageStatus status = default,
            SmsMessageError error = default, Platform platform = default, SmsMessageContent content = default,
            string campaignReferenceId = default, string mccMnc = default)
        {
            Sender = sender;
            Destination = destination;
            BulkId = bulkId;
            MessageId = messageId;
            SentAt = sentAt;
            DoneAt = doneAt;
            MessageCount = messageCount;
            Price = price;
            Status = status;
            Error = error;
            Platform = platform;
            Content = content;
            CampaignReferenceId = campaignReferenceId;
            MccMnc = mccMnc;
        }

        /// <summary>
        ///     The sender ID which can be alphanumeric or numeric.
        /// </summary>
        /// <value>The sender ID which can be alphanumeric or numeric.</value>
        [DataMember(Name = "sender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sender", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        /// <summary>
        ///     Message destination address.
        /// </summary>
        /// <value>Message destination address.</value>
        [DataMember(Name = "destination", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "destination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        /// <summary>
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API
        ///     request.
        /// </summary>
        /// <value>
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API
        ///     request.
        /// </value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bulkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("bulkId")]
        public string BulkId { get; set; }

        /// <summary>
        ///     Unique message ID for which a log is requested.
        /// </summary>
        /// <value>Unique message ID for which a log is requested.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Date and time when the message was sent. Has the following format: yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ.
        /// </summary>
        /// <value>Date and time when the message was sent. Has the following format: yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ.</value>
        [DataMember(Name = "sentAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sentAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sentAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        ///     Date and time when the Infobip services finished processing the message (i.e., delivered to the destination,
        ///     network, etc.). Has the following format: yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ.
        /// </summary>
        /// <value>
        ///     Date and time when the Infobip services finished processing the message (i.e., delivered to the destination,
        ///     network, etc.). Has the following format: yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ.
        /// </value>
        [DataMember(Name = "doneAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "doneAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("doneAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset DoneAt { get; set; }

        /// <summary>
        ///     The number of messages content was split to.
        /// </summary>
        /// <value>The number of messages content was split to.</value>
        [DataMember(Name = "messageCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        ///     Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("price")]
        public MessagePrice Price { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public SmsMessageStatus Status { get; set; }

        /// <summary>
        ///     Gets or Sets Error
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("error")]
        public SmsMessageError Error { get; set; }

        /// <summary>
        ///     Gets or Sets Platform
        /// </summary>
        [DataMember(Name = "platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "platform", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("platform")]
        public Platform Platform { get; set; }

        /// <summary>
        ///     Gets or Sets Content
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("content")]
        public SmsMessageContent Content { get; set; }

        /// <summary>
        ///     ID of a campaign that was sent in the message.
        /// </summary>
        /// <value>ID of a campaign that was sent in the message.</value>
        [DataMember(Name = "campaignReferenceId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "campaignReferenceId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("campaignReferenceId")]
        public string CampaignReferenceId { get; set; }

        /// <summary>
        ///     Mobile country and network codes.
        /// </summary>
        /// <value>Mobile country and network codes.</value>
        [DataMember(Name = "mccMnc", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mccMnc", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("mccMnc")]
        public string MccMnc { get; set; }

        /// <summary>
        ///     Returns true if SmsLog instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsLog to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsLog input)
        {
            if (input == null)
                return false;

            return
                (
                    Sender == input.Sender ||
                    (Sender != null &&
                     Sender.Equals(input.Sender))
                ) &&
                (
                    Destination == input.Destination ||
                    (Destination != null &&
                     Destination.Equals(input.Destination))
                ) &&
                (
                    BulkId == input.BulkId ||
                    (BulkId != null &&
                     BulkId.Equals(input.BulkId))
                ) &&
                (
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                ) &&
                (
                    SentAt == input.SentAt ||
                    (SentAt != null &&
                     SentAt.Equals(input.SentAt))
                ) &&
                (
                    DoneAt == input.DoneAt ||
                    (DoneAt != null &&
                     DoneAt.Equals(input.DoneAt))
                ) &&
                (
                    MessageCount == input.MessageCount ||
                    MessageCount.Equals(input.MessageCount)
                ) &&
                (
                    Price == input.Price ||
                    (Price != null &&
                     Price.Equals(input.Price))
                ) &&
                (
                    Status == input.Status ||
                    (Status != null &&
                     Status.Equals(input.Status))
                ) &&
                (
                    Error == input.Error ||
                    (Error != null &&
                     Error.Equals(input.Error))
                ) &&
                (
                    Platform == input.Platform ||
                    (Platform != null &&
                     Platform.Equals(input.Platform))
                ) &&
                (
                    Content == input.Content ||
                    (Content != null &&
                     Content.Equals(input.Content))
                ) &&
                (
                    CampaignReferenceId == input.CampaignReferenceId ||
                    (CampaignReferenceId != null &&
                     CampaignReferenceId.Equals(input.CampaignReferenceId))
                ) &&
                (
                    MccMnc == input.MccMnc ||
                    (MccMnc != null &&
                     MccMnc.Equals(input.MccMnc))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsLog {\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Destination: ").Append(Destination).Append("\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  SentAt: ").Append(SentAt).Append("\n");
            sb.Append("  DoneAt: ").Append(DoneAt).Append("\n");
            sb.Append("  MessageCount: ").Append(MessageCount).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  CampaignReferenceId: ").Append(CampaignReferenceId).Append("\n");
            sb.Append("  MccMnc: ").Append(MccMnc).Append("\n");
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
            return Equals(input as SmsLog);
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
                if (Sender != null)
                    hashCode = hashCode * 59 + Sender.GetHashCode();
                if (Destination != null)
                    hashCode = hashCode * 59 + Destination.GetHashCode();
                if (BulkId != null)
                    hashCode = hashCode * 59 + BulkId.GetHashCode();
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                if (SentAt != null)
                    hashCode = hashCode * 59 + SentAt.GetHashCode();
                if (DoneAt != null)
                    hashCode = hashCode * 59 + DoneAt.GetHashCode();
                hashCode = hashCode * 59 + MessageCount.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (Error != null)
                    hashCode = hashCode * 59 + Error.GetHashCode();
                if (Platform != null)
                    hashCode = hashCode * 59 + Platform.GetHashCode();
                if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                if (CampaignReferenceId != null)
                    hashCode = hashCode * 59 + CampaignReferenceId.GetHashCode();
                if (MccMnc != null)
                    hashCode = hashCode * 59 + MccMnc.GetHashCode();
                return hashCode;
            }
        }
    }
}