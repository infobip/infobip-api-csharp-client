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
    ///     Audio media properties.
    /// </summary>
    [DataContract(Name = "CallsAudioMediaProperties")]
    [JsonObject]
    public class CallsAudioMediaProperties : IEquatable<CallsAudioMediaProperties>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAudioMediaProperties" /> class.
        /// </summary>
        /// <param name="muted">Indicates whether the end user can speak..</param>
        /// <param name="userMuted">Indicates whether the end user muted himself..</param>
        /// <param name="deaf">Indicates whether the end user can hear..</param>
        public CallsAudioMediaProperties(bool muted = default, bool userMuted = default, bool deaf = default)
        {
            Muted = muted;
            UserMuted = userMuted;
            Deaf = deaf;
        }

        /// <summary>
        ///     Indicates whether the end user can speak.
        /// </summary>
        /// <value>Indicates whether the end user can speak.</value>
        [DataMember(Name = "muted", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "muted", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("muted")]
        public bool Muted { get; set; }

        /// <summary>
        ///     Indicates whether the end user muted himself.
        /// </summary>
        /// <value>Indicates whether the end user muted himself.</value>
        [DataMember(Name = "userMuted", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "userMuted", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("userMuted")]
        public bool UserMuted { get; set; }

        /// <summary>
        ///     Indicates whether the end user can hear.
        /// </summary>
        /// <value>Indicates whether the end user can hear.</value>
        [DataMember(Name = "deaf", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "deaf", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("deaf")]
        public bool Deaf { get; set; }

        /// <summary>
        ///     Returns true if CallsAudioMediaProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsAudioMediaProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsAudioMediaProperties input)
        {
            if (input == null)
                return false;

            return
                (
                    Muted == input.Muted ||
                    Muted.Equals(input.Muted)
                ) &&
                (
                    UserMuted == input.UserMuted ||
                    UserMuted.Equals(input.UserMuted)
                ) &&
                (
                    Deaf == input.Deaf ||
                    Deaf.Equals(input.Deaf)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsAudioMediaProperties {\n");
            sb.Append("  Muted: ").Append(Muted).Append("\n");
            sb.Append("  UserMuted: ").Append(UserMuted).Append("\n");
            sb.Append("  Deaf: ").Append(Deaf).Append("\n");
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
            return Equals(input as CallsAudioMediaProperties);
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
                hashCode = hashCode * 59 + Muted.GetHashCode();
                hashCode = hashCode * 59 + UserMuted.GetHashCode();
                hashCode = hashCode * 59 + Deaf.GetHashCode();
                return hashCode;
            }
        }
    }
}