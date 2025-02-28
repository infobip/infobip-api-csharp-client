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
    ///     CallsMediaProperties
    /// </summary>
    [DataContract(Name = "CallsMediaProperties")]
    [JsonObject]
    public class CallsMediaProperties : IEquatable<CallsMediaProperties>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsMediaProperties" /> class.
        /// </summary>
        /// <param name="audio">audio.</param>
        /// <param name="video">video.</param>
        public CallsMediaProperties(CallsAudioMediaProperties audio = default,
            CallsVideoMediaProperties video = default)
        {
            Audio = audio;
            Video = video;
        }

        /// <summary>
        ///     Gets or Sets Audio
        /// </summary>
        [DataMember(Name = "audio", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "audio", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("audio")]
        public CallsAudioMediaProperties Audio { get; set; }

        /// <summary>
        ///     Gets or Sets Video
        /// </summary>
        [DataMember(Name = "video", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "video", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("video")]
        public CallsVideoMediaProperties Video { get; set; }

        /// <summary>
        ///     Returns true if CallsMediaProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsMediaProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsMediaProperties input)
        {
            if (input == null)
                return false;

            return
                (
                    Audio == input.Audio ||
                    (Audio != null &&
                     Audio.Equals(input.Audio))
                ) &&
                (
                    Video == input.Video ||
                    (Video != null &&
                     Video.Equals(input.Video))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsMediaProperties {\n");
            sb.Append("  Audio: ").Append(Audio).Append("\n");
            sb.Append("  Video: ").Append(Video).Append("\n");
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
            return Equals(input as CallsMediaProperties);
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
                if (Audio != null)
                    hashCode = hashCode * 59 + Audio.GetHashCode();
                if (Video != null)
                    hashCode = hashCode * 59 + Video.GetHashCode();
                return hashCode;
            }
        }
    }
}