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
    ///     The array of objects for your sent messages.
    /// </summary>
    [DataContract(Name = "SmsWebhookInboundReportResponse")]
    [JsonObject]
    public class SmsWebhookInboundReportResponse : IEquatable<SmsWebhookInboundReportResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsWebhookInboundReportResponse" /> class.
        /// </summary>
        /// <param name="messageCount">Number of returned messages in this request..</param>
        /// <param name="pendingMessageCount">
        ///     Number of remaining new messages on Infobip servers ready to be returned in the next
        ///     request..
        /// </param>
        /// <param name="results">results.</param>
        public SmsWebhookInboundReportResponse(int messageCount = default, int pendingMessageCount = default,
            List<SmsWebhookInboundReport> results = default)
        {
            MessageCount = messageCount;
            PendingMessageCount = pendingMessageCount;
            Results = results;
        }

        /// <summary>
        ///     Number of returned messages in this request.
        /// </summary>
        /// <value>Number of returned messages in this request.</value>
        [DataMember(Name = "messageCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        ///     Number of remaining new messages on Infobip servers ready to be returned in the next request.
        /// </summary>
        /// <value>Number of remaining new messages on Infobip servers ready to be returned in the next request.</value>
        [DataMember(Name = "pendingMessageCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pendingMessageCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("pendingMessageCount")]
        public int PendingMessageCount { get; set; }

        /// <summary>
        ///     Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "results", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("results")]
        public List<SmsWebhookInboundReport> Results { get; set; }

        /// <summary>
        ///     Returns true if SmsWebhookInboundReportResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsWebhookInboundReportResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsWebhookInboundReportResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    MessageCount == input.MessageCount ||
                    MessageCount.Equals(input.MessageCount)
                ) &&
                (
                    PendingMessageCount == input.PendingMessageCount ||
                    PendingMessageCount.Equals(input.PendingMessageCount)
                ) &&
                (
                    Results == input.Results ||
                    (Results != null &&
                     input.Results != null &&
                     Results.SequenceEqual(input.Results))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsWebhookInboundReportResponse {\n");
            sb.Append("  MessageCount: ").Append(MessageCount).Append("\n");
            sb.Append("  PendingMessageCount: ").Append(PendingMessageCount).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
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
            return Equals(input as SmsWebhookInboundReportResponse);
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
                hashCode = hashCode * 59 + MessageCount.GetHashCode();
                hashCode = hashCode * 59 + PendingMessageCount.GetHashCode();
                if (Results != null)
                    hashCode = hashCode * 59 + Results.GetHashCode();
                return hashCode;
            }
        }
    }
}