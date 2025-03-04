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
    ///     CallsConferenceRequest
    /// </summary>
    [DataContract(Name = "CallsConferenceRequest")]
    [JsonObject]
    public class CallsConferenceRequest : IEquatable<CallsConferenceRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsConferenceRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsConferenceRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsConferenceRequest" /> class.
        /// </summary>
        /// <param name="name">Conference name, will be auto-generated if not provided..</param>
        /// <param name="recording">recording.</param>
        /// <param name="maxDuration">Max duration in seconds. (default to 28800).</param>
        /// <param name="callsConfigurationId">Calls Configuration ID. (required).</param>
        /// <param name="platform">platform.</param>
        public CallsConferenceRequest(string name = default, CallsConferenceRecordingRequest recording = default,
            int maxDuration = 28800, string callsConfigurationId = default, Platform platform = default)
        {
            // to ensure "callsConfigurationId" is required (not null)
            CallsConfigurationId = callsConfigurationId ?? throw new ArgumentNullException("callsConfigurationId");
            Name = name;
            Recording = recording;
            MaxDuration = maxDuration;
            Platform = platform;
        }

        /// <summary>
        ///     Conference name, will be auto-generated if not provided.
        /// </summary>
        /// <value>Conference name, will be auto-generated if not provided.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets Recording
        /// </summary>
        [DataMember(Name = "recording", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "recording", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("recording")]
        public CallsConferenceRecordingRequest Recording { get; set; }

        /// <summary>
        ///     Max duration in seconds.
        /// </summary>
        /// <value>Max duration in seconds.</value>
        [DataMember(Name = "maxDuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxDuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; }

        /// <summary>
        ///     Calls Configuration ID.
        /// </summary>
        /// <value>Calls Configuration ID.</value>
        [DataMember(Name = "callsConfigurationId", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "callsConfigurationId", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
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
        ///     Returns true if CallsConferenceRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsConferenceRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsConferenceRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    Name == input.Name ||
                    (Name != null &&
                     Name.Equals(input.Name))
                ) &&
                (
                    Recording == input.Recording ||
                    (Recording != null &&
                     Recording.Equals(input.Recording))
                ) &&
                (
                    MaxDuration == input.MaxDuration ||
                    MaxDuration.Equals(input.MaxDuration)
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
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsConferenceRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Recording: ").Append(Recording).Append("\n");
            sb.Append("  MaxDuration: ").Append(MaxDuration).Append("\n");
            sb.Append("  CallsConfigurationId: ").Append(CallsConfigurationId).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
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
            return Equals(input as CallsConferenceRequest);
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Recording != null)
                    hashCode = hashCode * 59 + Recording.GetHashCode();
                hashCode = hashCode * 59 + MaxDuration.GetHashCode();
                if (CallsConfigurationId != null)
                    hashCode = hashCode * 59 + CallsConfigurationId.GetHashCode();
                if (Platform != null)
                    hashCode = hashCode * 59 + Platform.GetHashCode();
                return hashCode;
            }
        }
    }
}