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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     SmsInboundMessage
    /// </summary>
    [DataContract(Name = "SmsInboundMessage")]
    public class SmsInboundMessage : IEquatable<SmsInboundMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsInboundMessage" /> class.
        /// </summary>
        /// <param name="price">price.</param>
        public SmsInboundMessage(SmsPrice price = default)
        {
            Price = price;
        }

        /// <summary>
        ///     Custom callback data can be inserted during the setup phase.
        /// </summary>
        /// <value>Custom callback data can be inserted during the setup phase.</value>
        [DataMember(Name = "callbackData", EmitDefaultValue = false)]
        public string CallbackData { get; private set; }

        /// <summary>
        ///     Text of received message without a keyword (if a keyword was sent).
        /// </summary>
        /// <value>Text of received message without a keyword (if a keyword was sent).</value>
        [DataMember(Name = "cleanText", EmitDefaultValue = false)]
        public string CleanText { get; private set; }

        /// <summary>
        ///     Sender ID that can be alphanumeric or numeric.
        /// </summary>
        /// <value>Sender ID that can be alphanumeric or numeric.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; private set; }

        /// <summary>
        ///     Keyword extracted from the message text.
        /// </summary>
        /// <value>Keyword extracted from the message text.</value>
        [DataMember(Name = "keyword", EmitDefaultValue = false)]
        public string Keyword { get; private set; }

        /// <summary>
        ///     The ID that uniquely identifies the received message.
        /// </summary>
        /// <value>The ID that uniquely identifies the received message.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        public string MessageId { get; private set; }

        /// <summary>
        ///     Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public SmsPrice Price { get; set; }

        /// <summary>
        ///     Tells when Infobip platform received the message. It has the following format: &#x60;yyyy-MM-dd&#39;T&#39;
        ///     HH:mm:ss.SSSZ&#x60;.
        /// </summary>
        /// <value>
        ///     Tells when Infobip platform received the message. It has the following format: &#x60;yyyy-MM-dd&#39;T&#39;
        ///     HH:mm:ss.SSSZ&#x60;.
        /// </value>
        [DataMember(Name = "receivedAt", EmitDefaultValue = false)]
        public DateTimeOffset ReceivedAt { get; private set; }

        /// <summary>
        ///     The number of sent message segments.
        /// </summary>
        /// <value>The number of sent message segments.</value>
        [DataMember(Name = "smsCount", EmitDefaultValue = false)]
        public int SmsCount { get; private set; }

        /// <summary>
        ///     Full text of the received message.
        /// </summary>
        /// <value>Full text of the received message.</value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; private set; }

        /// <summary>
        ///     The message destination address.
        /// </summary>
        /// <value>The message destination address.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; private set; }

        /// <summary>
        ///     Returns false as CallbackData should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCallbackData()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as CleanText should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCleanText()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as From should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFrom()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as Keyword should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeKeyword()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as MessageId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeMessageId()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as ReceivedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeReceivedAt()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as SmsCount should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSmsCount()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as Text should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeText()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as To should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTo()
        {
            return false;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsInboundMessage {\n");
            sb.Append("  CallbackData: ").Append(CallbackData).Append("\n");
            sb.Append("  CleanText: ").Append(CleanText).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Keyword: ").Append(Keyword).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  ReceivedAt: ").Append(ReceivedAt).Append("\n");
            sb.Append("  SmsCount: ").Append(SmsCount).Append("\n");
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
            return Equals(input as SmsInboundMessage);
        }

        /// <summary>
        ///     Returns true if SmsInboundMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsInboundMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsInboundMessage input)
        {
            if (input == null)
                return false;

            return
                (
                    CallbackData == input.CallbackData ||
                    CallbackData != null &&
                    CallbackData.Equals(input.CallbackData)
                ) &&
                (
                    CleanText == input.CleanText ||
                    CleanText != null &&
                    CleanText.Equals(input.CleanText)
                ) &&
                (
                    From == input.From ||
                    From != null &&
                    From.Equals(input.From)
                ) &&
                (
                    Keyword == input.Keyword ||
                    Keyword != null &&
                    Keyword.Equals(input.Keyword)
                ) &&
                (
                    MessageId == input.MessageId ||
                    MessageId != null &&
                    MessageId.Equals(input.MessageId)
                ) &&
                (
                    Price == input.Price ||
                    Price != null &&
                    Price.Equals(input.Price)
                ) &&
                (
                    ReceivedAt == input.ReceivedAt ||
                    ReceivedAt != null &&
                    ReceivedAt.Equals(input.ReceivedAt)
                ) &&
                (
                    SmsCount == input.SmsCount ||
                    SmsCount.Equals(input.SmsCount)
                ) &&
                (
                    Text == input.Text ||
                    Text != null &&
                    Text.Equals(input.Text)
                ) &&
                (
                    To == input.To ||
                    To != null &&
                    To.Equals(input.To)
                );
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (CallbackData != null)
                    hashCode = hashCode * 59 + CallbackData.GetHashCode();
                if (CleanText != null)
                    hashCode = hashCode * 59 + CleanText.GetHashCode();
                if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                if (Keyword != null)
                    hashCode = hashCode * 59 + Keyword.GetHashCode();
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                if (ReceivedAt != null)
                    hashCode = hashCode * 59 + ReceivedAt.GetHashCode();
                hashCode = hashCode * 59 + SmsCount.GetHashCode();
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                return hashCode;
            }
        }
    }
}