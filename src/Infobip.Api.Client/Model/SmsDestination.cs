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
    ///     An array of destination objects for where messages are being sent. A valid destination is required.
    /// </summary>
    [DataContract(Name = "SmsDestination")]
    [JsonObject]
    public class SmsDestination : IEquatable<SmsDestination>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsDestination" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SmsDestination()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsDestination" /> class.
        /// </summary>
        /// <param name="to">The destination address of the message. (required).</param>
        /// <param name="messageId">The ID that uniquely identifies the message sent..</param>
        /// <param name="networkId">
        ///     Available in US and Canada only if networkId is known for Network Operator of the destination.
        ///     Returned in [SMS message delivery
        ///     reports](https://www.infobip.com/docs/api/channels/sms/sms-messaging/logs-and-status-reports) and [Inbound
        ///     SMS](https://www.infobip.com/docs/api/channels/sms/sms-messaging/inbound-sms); contact Infobip Support to enable..
        /// </param>
        public SmsDestination(string to = default, string messageId = default, int networkId = default)
        {
            // to ensure "to" is required (not null)
            To = to ?? throw new ArgumentNullException("to");
            MessageId = messageId;
            NetworkId = networkId;
        }

        /// <summary>
        ///     The destination address of the message.
        /// </summary>
        /// <value>The destination address of the message.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "to", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     The ID that uniquely identifies the message sent.
        /// </summary>
        /// <value>The ID that uniquely identifies the message sent.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Available in US and Canada only if networkId is known for Network Operator of the destination. Returned in [SMS
        ///     message delivery reports](https://www.infobip.com/docs/api/channels/sms/sms-messaging/logs-and-status-reports) and
        ///     [Inbound SMS](https://www.infobip.com/docs/api/channels/sms/sms-messaging/inbound-sms); contact Infobip Support to
        ///     enable.
        /// </summary>
        /// <value>
        ///     Available in US and Canada only if networkId is known for Network Operator of the destination. Returned in [SMS
        ///     message delivery reports](https://www.infobip.com/docs/api/channels/sms/sms-messaging/logs-and-status-reports) and
        ///     [Inbound SMS](https://www.infobip.com/docs/api/channels/sms/sms-messaging/inbound-sms); contact Infobip Support to
        ///     enable.
        /// </value>
        [DataMember(Name = "networkId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "networkId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("networkId")]
        public int NetworkId { get; set; }

        /// <summary>
        ///     Returns true if SmsDestination instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsDestination to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsDestination input)
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
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                ) &&
                (
                    NetworkId == input.NetworkId ||
                    NetworkId.Equals(input.NetworkId)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsDestination {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  NetworkId: ").Append(NetworkId).Append("\n");
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
            return Equals(input as SmsDestination);
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
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                hashCode = hashCode * 59 + NetworkId.GetHashCode();
                return hashCode;
            }
        }
    }
}