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
    ///     Video media properties.
    /// </summary>
    [DataContract(Name = "CallsVideoMediaProperties")]
    [JsonObject]
    public class CallsVideoMediaProperties : IEquatable<CallsVideoMediaProperties>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsVideoMediaProperties" /> class.
        /// </summary>
        /// <param name="camera">Indicates whether there is a video feed..</param>
        /// <param name="screenShare">Indicates whether the end user is sharing their screen..</param>
        public CallsVideoMediaProperties(bool camera = default, bool screenShare = default)
        {
            Camera = camera;
            ScreenShare = screenShare;
        }

        /// <summary>
        ///     Indicates whether there is a video feed.
        /// </summary>
        /// <value>Indicates whether there is a video feed.</value>
        [DataMember(Name = "camera", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "camera", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("camera")]
        public bool Camera { get; set; }

        /// <summary>
        ///     Indicates whether the end user is sharing their screen.
        /// </summary>
        /// <value>Indicates whether the end user is sharing their screen.</value>
        [DataMember(Name = "screenShare", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "screenShare", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("screenShare")]
        public bool ScreenShare { get; set; }

        /// <summary>
        ///     Returns true if CallsVideoMediaProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsVideoMediaProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsVideoMediaProperties input)
        {
            if (input == null)
                return false;

            return
                (
                    Camera == input.Camera ||
                    Camera.Equals(input.Camera)
                ) &&
                (
                    ScreenShare == input.ScreenShare ||
                    ScreenShare.Equals(input.ScreenShare)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsVideoMediaProperties {\n");
            sb.Append("  Camera: ").Append(Camera).Append("\n");
            sb.Append("  ScreenShare: ").Append(ScreenShare).Append("\n");
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
            return Equals(input as CallsVideoMediaProperties);
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
                hashCode = hashCode * 59 + Camera.GetHashCode();
                hashCode = hashCode * 59 + ScreenShare.GetHashCode();
                return hashCode;
            }
        }
    }
}