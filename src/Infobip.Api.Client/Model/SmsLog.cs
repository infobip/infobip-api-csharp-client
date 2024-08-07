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
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     SmsLog
    /// </summary>
    [DataContract(Name = "SmsLog")]
    public class SmsLog : IEquatable<SmsLog>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsLog" /> class.
        /// </summary>
        /// <param name="applicationId">
        ///     Application id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management)..
        /// </param>
        /// <param name="bulkId">
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages
        ///     via a single API request..
        /// </param>
        /// <param name="campaignReferenceId">ID of a campaign that was sent in the message..</param>
        /// <param name="doneAt">
        ///     Date and time when the Infobip services finished processing the message (i.e. delivered to the
        ///     destination, delivered to the destination network, etc.). Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;
        ///     HH:mm:ss.SSSZ&#x60;..
        /// </param>
        /// <param name="entityId">
        ///     Entity id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management)..
        /// </param>
        /// <param name="error">error.</param>
        /// <param name="from">Sender ID that can be alphanumeric or numeric..</param>
        /// <param name="mccMnc">Mobile country and network codes..</param>
        /// <param name="messageId">Unique message ID..</param>
        /// <param name="price">price.</param>
        /// <param name="sentAt">
        ///     Date and time when the message was
        ///     [scheduled](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) to be sent. Has the following
        ///     format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;..
        /// </param>
        /// <param name="smsCount">The number of parts the message content was split into..</param>
        /// <param name="status">status.</param>
        /// <param name="text">Content of the message being sent..</param>
        /// <param name="to">The destination address of the message..</param>
        public SmsLog(string applicationId = default, string bulkId = default, string campaignReferenceId = default,
            DateTimeOffset doneAt = default, string entityId = default, MessageError error = default,
            string from = default, string mccMnc = default, string messageId = default, MessagePrice price = default,
            DateTimeOffset sentAt = default, int smsCount = default, MessageStatus status = default,
            string text = default, string to = default)
        {
            ApplicationId = applicationId;
            BulkId = bulkId;
            CampaignReferenceId = campaignReferenceId;
            DoneAt = doneAt;
            EntityId = entityId;
            Error = error;
            From = from;
            MccMnc = mccMnc;
            MessageId = messageId;
            Price = price;
            SentAt = sentAt;
            SmsCount = smsCount;
            Status = status;
            Text = text;
            To = to;
        }

        /// <summary>
        ///     Application id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management).
        /// </summary>
        /// <value>
        ///     Application id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management).
        /// </value>
        [DataMember(Name = "applicationId", EmitDefaultValue = false)]
        public string ApplicationId { get; set; }

        /// <summary>
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API
        ///     request.
        /// </summary>
        /// <value>
        ///     Unique ID assigned to the request if messaging multiple recipients or sending multiple messages via a single API
        ///     request.
        /// </value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        public string BulkId { get; set; }

        /// <summary>
        ///     ID of a campaign that was sent in the message.
        /// </summary>
        /// <value>ID of a campaign that was sent in the message.</value>
        [DataMember(Name = "campaignReferenceId", EmitDefaultValue = false)]
        public string CampaignReferenceId { get; set; }

        /// <summary>
        ///     Date and time when the Infobip services finished processing the message (i.e. delivered to the destination,
        ///     delivered to the destination network, etc.). Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ
        ///     &#x60;.
        /// </summary>
        /// <value>
        ///     Date and time when the Infobip services finished processing the message (i.e. delivered to the destination,
        ///     delivered to the destination network, etc.). Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ
        ///     &#x60;.
        /// </value>
        [DataMember(Name = "doneAt", EmitDefaultValue = false)]
        public DateTimeOffset DoneAt { get; set; }

        /// <summary>
        ///     Entity id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management).
        /// </summary>
        /// <value>
        ///     Entity id used to send the message. For more details, see our
        ///     [documentation](https://www.infobip.com/docs/cpaas-x/application-and-entity-management).
        /// </value>
        [DataMember(Name = "entityId", EmitDefaultValue = false)]
        public string EntityId { get; set; }

        /// <summary>
        ///     Gets or Sets Error
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public MessageError Error { get; set; }

        /// <summary>
        ///     Sender ID that can be alphanumeric or numeric.
        /// </summary>
        /// <value>Sender ID that can be alphanumeric or numeric.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        /// <summary>
        ///     Mobile country and network codes.
        /// </summary>
        /// <value>Mobile country and network codes.</value>
        [DataMember(Name = "mccMnc", EmitDefaultValue = false)]
        public string MccMnc { get; set; }

        /// <summary>
        ///     Unique message ID.
        /// </summary>
        /// <value>Unique message ID.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        public string MessageId { get; set; }

        /// <summary>
        ///     Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public MessagePrice Price { get; set; }

        /// <summary>
        ///     Date and time when the message was
        ///     [scheduled](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) to be sent. Has the following
        ///     format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.
        /// </summary>
        /// <value>
        ///     Date and time when the message was
        ///     [scheduled](https://www.infobip.com/docs/api#channels/sms/get-scheduled-sms-messages) to be sent. Has the following
        ///     format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.
        /// </value>
        [DataMember(Name = "sentAt", EmitDefaultValue = false)]
        public DateTimeOffset SentAt { get; set; }

        /// <summary>
        ///     The number of parts the message content was split into.
        /// </summary>
        /// <value>The number of parts the message content was split into.</value>
        [DataMember(Name = "smsCount", EmitDefaultValue = false)]
        public int SmsCount { get; set; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public MessageStatus Status { get; set; }

        /// <summary>
        ///     Content of the message being sent.
        /// </summary>
        /// <value>Content of the message being sent.</value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        ///     The destination address of the message.
        /// </summary>
        /// <value>The destination address of the message.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

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
                    ApplicationId == input.ApplicationId ||
                    (ApplicationId != null &&
                     ApplicationId.Equals(input.ApplicationId))
                ) &&
                (
                    BulkId == input.BulkId ||
                    (BulkId != null &&
                     BulkId.Equals(input.BulkId))
                ) &&
                (
                    CampaignReferenceId == input.CampaignReferenceId ||
                    (CampaignReferenceId != null &&
                     CampaignReferenceId.Equals(input.CampaignReferenceId))
                ) &&
                (
                    DoneAt == input.DoneAt ||
                    (DoneAt != null &&
                     DoneAt.Equals(input.DoneAt))
                ) &&
                (
                    EntityId == input.EntityId ||
                    (EntityId != null &&
                     EntityId.Equals(input.EntityId))
                ) &&
                (
                    Error == input.Error ||
                    (Error != null &&
                     Error.Equals(input.Error))
                ) &&
                (
                    From == input.From ||
                    (From != null &&
                     From.Equals(input.From))
                ) &&
                (
                    MccMnc == input.MccMnc ||
                    (MccMnc != null &&
                     MccMnc.Equals(input.MccMnc))
                ) &&
                (
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                ) &&
                (
                    Price == input.Price ||
                    (Price != null &&
                     Price.Equals(input.Price))
                ) &&
                (
                    SentAt == input.SentAt ||
                    (SentAt != null &&
                     SentAt.Equals(input.SentAt))
                ) &&
                (
                    SmsCount == input.SmsCount ||
                    SmsCount.Equals(input.SmsCount)
                ) &&
                (
                    Status == input.Status ||
                    (Status != null &&
                     Status.Equals(input.Status))
                ) &&
                (
                    Text == input.Text ||
                    (Text != null &&
                     Text.Equals(input.Text))
                ) &&
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
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
            sb.Append("  ApplicationId: ").Append(ApplicationId).Append("\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
            sb.Append("  CampaignReferenceId: ").Append(CampaignReferenceId).Append("\n");
            sb.Append("  DoneAt: ").Append(DoneAt).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  MccMnc: ").Append(MccMnc).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  SentAt: ").Append(SentAt).Append("\n");
            sb.Append("  SmsCount: ").Append(SmsCount).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
                if (ApplicationId != null)
                    hashCode = hashCode * 59 + ApplicationId.GetHashCode();
                if (BulkId != null)
                    hashCode = hashCode * 59 + BulkId.GetHashCode();
                if (CampaignReferenceId != null)
                    hashCode = hashCode * 59 + CampaignReferenceId.GetHashCode();
                if (DoneAt != null)
                    hashCode = hashCode * 59 + DoneAt.GetHashCode();
                if (EntityId != null)
                    hashCode = hashCode * 59 + EntityId.GetHashCode();
                if (Error != null)
                    hashCode = hashCode * 59 + Error.GetHashCode();
                if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                if (MccMnc != null)
                    hashCode = hashCode * 59 + MccMnc.GetHashCode();
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                if (SentAt != null)
                    hashCode = hashCode * 59 + SentAt.GetHashCode();
                hashCode = hashCode * 59 + SmsCount.GetHashCode();
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                return hashCode;
            }
        }
    }
}