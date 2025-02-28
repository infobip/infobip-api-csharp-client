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
    ///     CallsConferenceBroadcastWebrtcTextRequest
    /// </summary>
    [DataContract(Name = "CallsConferenceBroadcastWebrtcTextRequest")]
    [JsonObject]
    public class CallsConferenceBroadcastWebrtcTextRequest : IEquatable<CallsConferenceBroadcastWebrtcTextRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsConferenceBroadcastWebrtcTextRequest" /> class.
        /// </summary>
        /// <param name="text">Text to broadcast..</param>
        public CallsConferenceBroadcastWebrtcTextRequest(string text = default)
        {
            Text = text;
        }

        /// <summary>
        ///     Text to broadcast.
        /// </summary>
        /// <value>Text to broadcast.</value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Returns true if CallsConferenceBroadcastWebrtcTextRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsConferenceBroadcastWebrtcTextRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsConferenceBroadcastWebrtcTextRequest input)
        {
            if (input == null)
                return false;

            return
                Text == input.Text ||
                (Text != null &&
                 Text.Equals(input.Text));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsConferenceBroadcastWebrtcTextRequest {\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
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
            return Equals(input as CallsConferenceBroadcastWebrtcTextRequest);
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
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                return hashCode;
            }
        }
    }
}