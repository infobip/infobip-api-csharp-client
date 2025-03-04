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
    ///     Array of recorded files metadata, one for each recorded file.
    /// </summary>
    [DataContract(Name = "CallsRecordedIvrFile")]
    [JsonObject]
    public class CallsRecordedIvrFile : IEquatable<CallsRecordedIvrFile>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsRecordedIvrFile" /> class.
        /// </summary>
        /// <param name="messageId">The ID that uniquely identifies the sent message..</param>
        /// <param name="from">Numeric sender ID..</param>
        /// <param name="to">Destination address..</param>
        /// <param name="scenarioId">Scenario key..</param>
        /// <param name="groupId">Differentiates recordings made by separate Record actions..</param>
        /// <param name="url">
        ///     Relative URL path to the recorded file. To download the audio, just perform a GET request using the
        ///     relative URL of a specific file. The returned audio data is encoded as PCM 16bit 8kHz WAVE audio. The files are
        ///     available on Infobip servers for 2 months..
        /// </param>
        /// <param name="recordedAt">The time the recording took place..</param>
        public CallsRecordedIvrFile(string messageId = default, string from = default, string to = default,
            string scenarioId = default, string groupId = default, string url = default,
            DateTimeOffset recordedAt = default)
        {
            MessageId = messageId;
            From = from;
            To = to;
            ScenarioId = scenarioId;
            GroupId = groupId;
            Url = url;
            RecordedAt = recordedAt;
        }

        /// <summary>
        ///     The ID that uniquely identifies the sent message.
        /// </summary>
        /// <value>The ID that uniquely identifies the sent message.</value>
        [DataMember(Name = "messageId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Numeric sender ID.
        /// </summary>
        /// <value>Numeric sender ID.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "from", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("from")]
        public string From { get; set; }

        /// <summary>
        ///     Destination address.
        /// </summary>
        /// <value>Destination address.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     Scenario key.
        /// </summary>
        /// <value>Scenario key.</value>
        [DataMember(Name = "scenarioId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scenarioId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("scenarioId")]
        public string ScenarioId { get; set; }

        /// <summary>
        ///     Differentiates recordings made by separate Record actions.
        /// </summary>
        /// <value>Differentiates recordings made by separate Record actions.</value>
        [DataMember(Name = "groupId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "groupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        ///     Relative URL path to the recorded file. To download the audio, just perform a GET request using the relative URL of
        ///     a specific file. The returned audio data is encoded as PCM 16bit 8kHz WAVE audio. The files are available on
        ///     Infobip servers for 2 months.
        /// </summary>
        /// <value>
        ///     Relative URL path to the recorded file. To download the audio, just perform a GET request using the relative URL
        ///     of a specific file. The returned audio data is encoded as PCM 16bit 8kHz WAVE audio. The files are available on
        ///     Infobip servers for 2 months.
        /// </value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        ///     The time the recording took place.
        /// </summary>
        /// <value>The time the recording took place.</value>
        [DataMember(Name = "recordedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "recordedAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("recordedAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset RecordedAt { get; set; }

        /// <summary>
        ///     Returns true if CallsRecordedIvrFile instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsRecordedIvrFile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsRecordedIvrFile input)
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
                    From == input.From ||
                    (From != null &&
                     From.Equals(input.From))
                ) &&
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
                ) &&
                (
                    ScenarioId == input.ScenarioId ||
                    (ScenarioId != null &&
                     ScenarioId.Equals(input.ScenarioId))
                ) &&
                (
                    GroupId == input.GroupId ||
                    (GroupId != null &&
                     GroupId.Equals(input.GroupId))
                ) &&
                (
                    Url == input.Url ||
                    (Url != null &&
                     Url.Equals(input.Url))
                ) &&
                (
                    RecordedAt == input.RecordedAt ||
                    (RecordedAt != null &&
                     RecordedAt.Equals(input.RecordedAt))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsRecordedIvrFile {\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  ScenarioId: ").Append(ScenarioId).Append("\n");
            sb.Append("  GroupId: ").Append(GroupId).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  RecordedAt: ").Append(RecordedAt).Append("\n");
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
            return Equals(input as CallsRecordedIvrFile);
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
                if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                if (ScenarioId != null)
                    hashCode = hashCode * 59 + ScenarioId.GetHashCode();
                if (GroupId != null)
                    hashCode = hashCode * 59 + GroupId.GetHashCode();
                if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                if (RecordedAt != null)
                    hashCode = hashCode * 59 + RecordedAt.GetHashCode();
                return hashCode;
            }
        }
    }
}