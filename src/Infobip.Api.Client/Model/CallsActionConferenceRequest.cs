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
    ///     CallsActionConferenceRequest
    /// </summary>
    [DataContract(Name = "CallsActionConferenceRequest")]
    [JsonObject]
    public class CallsActionConferenceRequest : IEquatable<CallsActionConferenceRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsActionConferenceRequest" /> class.
        /// </summary>
        /// <param name="name">Conference name, will be auto-generated if not provided..</param>
        /// <param name="recording">recording.</param>
        /// <param name="maxDuration">Max duration in seconds. (default to 28800).</param>
        public CallsActionConferenceRequest(string name = default, CallsConferenceRecordingRequest recording = default,
            int maxDuration = 28800)
        {
            Name = name;
            Recording = recording;
            MaxDuration = maxDuration;
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
        ///     Returns true if CallsActionConferenceRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsActionConferenceRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsActionConferenceRequest input)
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
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsActionConferenceRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Recording: ").Append(Recording).Append("\n");
            sb.Append("  MaxDuration: ").Append(MaxDuration).Append("\n");
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
            return Equals(input as CallsActionConferenceRequest);
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
                return hashCode;
            }
        }
    }
}