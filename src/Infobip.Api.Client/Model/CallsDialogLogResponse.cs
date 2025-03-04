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
    ///     CallsDialogLogResponse
    /// </summary>
    [DataContract(Name = "CallsDialogLogResponse")]
    [JsonObject]
    public class CallsDialogLogResponse : IEquatable<CallsDialogLogResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsDialogLogResponse" /> class.
        /// </summary>
        /// <param name="dialogId">Unique dialog ID..</param>
        /// <param name="callsConfigurationId">Calls Configuration ID..</param>
        /// <param name="platform">platform.</param>
        /// <param name="state">state.</param>
        /// <param name="startTime">Date and time for when the dialog has been created..</param>
        /// <param name="establishTime">Date and time for when the dialog has been established..</param>
        /// <param name="endTime">Date and time for when the dialog has been finished..</param>
        /// <param name="parentCallId">Unique parent call ID..</param>
        /// <param name="childCallId">Unique child call ID..</param>
        /// <param name="duration">Dialog duration in seconds..</param>
        /// <param name="recording">recording.</param>
        /// <param name="errorCode">errorCode.</param>
        public CallsDialogLogResponse(string dialogId = default, string callsConfigurationId = default,
            Platform platform = default, CallsDialogState? state = default, DateTimeOffset startTime = default,
            DateTimeOffset establishTime = default, DateTimeOffset endTime = default, string parentCallId = default,
            string childCallId = default, long duration = default, CallsDialogRecordingLog recording = default,
            CallsErrorCodeInfo errorCode = default)
        {
            DialogId = dialogId;
            CallsConfigurationId = callsConfigurationId;
            Platform = platform;
            State = state;
            StartTime = startTime;
            EstablishTime = establishTime;
            EndTime = endTime;
            ParentCallId = parentCallId;
            ChildCallId = childCallId;
            Duration = duration;
            Recording = recording;
            ErrorCode = errorCode;
        }

        /// <summary>
        ///     Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "state", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("state")]
        public CallsDialogState? State { get; set; }

        /// <summary>
        ///     Unique dialog ID.
        /// </summary>
        /// <value>Unique dialog ID.</value>
        [DataMember(Name = "dialogId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "dialogId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("dialogId")]
        public string DialogId { get; set; }

        /// <summary>
        ///     Calls Configuration ID.
        /// </summary>
        /// <value>Calls Configuration ID.</value>
        [DataMember(Name = "callsConfigurationId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "callsConfigurationId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("callsConfigurationId")]
        public string CallsConfigurationId { get; set; }

        /// <summary>
        ///     Gets or Sets Platform
        /// </summary>
        [DataMember(Name = "platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "platform", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("platform")]
        public Platform Platform { get; set; }

        /// <summary>
        ///     Date and time for when the dialog has been created.
        /// </summary>
        /// <value>Date and time for when the dialog has been created.</value>
        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("startTime")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        ///     Date and time for when the dialog has been established.
        /// </summary>
        /// <value>Date and time for when the dialog has been established.</value>
        [DataMember(Name = "establishTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "establishTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("establishTime")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset EstablishTime { get; set; }

        /// <summary>
        ///     Date and time for when the dialog has been finished.
        /// </summary>
        /// <value>Date and time for when the dialog has been finished.</value>
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("endTime")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        ///     Unique parent call ID.
        /// </summary>
        /// <value>Unique parent call ID.</value>
        [DataMember(Name = "parentCallId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "parentCallId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("parentCallId")]
        public string ParentCallId { get; set; }

        /// <summary>
        ///     Unique child call ID.
        /// </summary>
        /// <value>Unique child call ID.</value>
        [DataMember(Name = "childCallId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "childCallId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("childCallId")]
        public string ChildCallId { get; set; }

        /// <summary>
        ///     Dialog duration in seconds.
        /// </summary>
        /// <value>Dialog duration in seconds.</value>
        [DataMember(Name = "duration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        ///     Gets or Sets Recording
        /// </summary>
        [DataMember(Name = "recording", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "recording", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("recording")]
        public CallsDialogRecordingLog Recording { get; set; }

        /// <summary>
        ///     Gets or Sets ErrorCode
        /// </summary>
        [DataMember(Name = "errorCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "errorCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("errorCode")]
        public CallsErrorCodeInfo ErrorCode { get; set; }

        /// <summary>
        ///     Returns true if CallsDialogLogResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsDialogLogResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsDialogLogResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    DialogId == input.DialogId ||
                    (DialogId != null &&
                     DialogId.Equals(input.DialogId))
                ) &&
                (
                    CallsConfigurationId == input.CallsConfigurationId ||
                    (CallsConfigurationId != null &&
                     CallsConfigurationId.Equals(input.CallsConfigurationId))
                ) &&
                (
                    Platform == input.Platform ||
                    (Platform != null &&
                     Platform.Equals(input.Platform))
                ) &&
                (
                    State == input.State ||
                    State.Equals(input.State)
                ) &&
                (
                    StartTime == input.StartTime ||
                    (StartTime != null &&
                     StartTime.Equals(input.StartTime))
                ) &&
                (
                    EstablishTime == input.EstablishTime ||
                    (EstablishTime != null &&
                     EstablishTime.Equals(input.EstablishTime))
                ) &&
                (
                    EndTime == input.EndTime ||
                    (EndTime != null &&
                     EndTime.Equals(input.EndTime))
                ) &&
                (
                    ParentCallId == input.ParentCallId ||
                    (ParentCallId != null &&
                     ParentCallId.Equals(input.ParentCallId))
                ) &&
                (
                    ChildCallId == input.ChildCallId ||
                    (ChildCallId != null &&
                     ChildCallId.Equals(input.ChildCallId))
                ) &&
                (
                    Duration == input.Duration ||
                    Duration.Equals(input.Duration)
                ) &&
                (
                    Recording == input.Recording ||
                    (Recording != null &&
                     Recording.Equals(input.Recording))
                ) &&
                (
                    ErrorCode == input.ErrorCode ||
                    (ErrorCode != null &&
                     ErrorCode.Equals(input.ErrorCode))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsDialogLogResponse {\n");
            sb.Append("  DialogId: ").Append(DialogId).Append("\n");
            sb.Append("  CallsConfigurationId: ").Append(CallsConfigurationId).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  EstablishTime: ").Append(EstablishTime).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  ParentCallId: ").Append(ParentCallId).Append("\n");
            sb.Append("  ChildCallId: ").Append(ChildCallId).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Recording: ").Append(Recording).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
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
            return Equals(input as CallsDialogLogResponse);
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
                if (DialogId != null)
                    hashCode = hashCode * 59 + DialogId.GetHashCode();
                if (CallsConfigurationId != null)
                    hashCode = hashCode * 59 + CallsConfigurationId.GetHashCode();
                if (Platform != null)
                    hashCode = hashCode * 59 + Platform.GetHashCode();
                hashCode = hashCode * 59 + State.GetHashCode();
                if (StartTime != null)
                    hashCode = hashCode * 59 + StartTime.GetHashCode();
                if (EstablishTime != null)
                    hashCode = hashCode * 59 + EstablishTime.GetHashCode();
                if (EndTime != null)
                    hashCode = hashCode * 59 + EndTime.GetHashCode();
                if (ParentCallId != null)
                    hashCode = hashCode * 59 + ParentCallId.GetHashCode();
                if (ChildCallId != null)
                    hashCode = hashCode * 59 + ChildCallId.GetHashCode();
                hashCode = hashCode * 59 + Duration.GetHashCode();
                if (Recording != null)
                    hashCode = hashCode * 59 + Recording.GetHashCode();
                if (ErrorCode != null)
                    hashCode = hashCode * 59 + ErrorCode.GetHashCode();
                return hashCode;
            }
        }
    }
}