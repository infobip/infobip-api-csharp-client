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
    ///     CallsStartTranscriptionRequest
    /// </summary>
    [DataContract(Name = "CallsStartTranscriptionRequest")]
    [JsonObject]
    public class CallsStartTranscriptionRequest : IEquatable<CallsStartTranscriptionRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsStartTranscriptionRequest" /> class.
        /// </summary>
        /// <param name="transcription">transcription.</param>
        public CallsStartTranscriptionRequest(CallsTranscription transcription = default)
        {
            Transcription = transcription;
        }

        /// <summary>
        ///     Gets or Sets Transcription
        /// </summary>
        [DataMember(Name = "transcription", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "transcription", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("transcription")]
        public CallsTranscription Transcription { get; set; }

        /// <summary>
        ///     Returns true if CallsStartTranscriptionRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsStartTranscriptionRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsStartTranscriptionRequest input)
        {
            if (input == null)
                return false;

            return
                Transcription == input.Transcription ||
                (Transcription != null &&
                 Transcription.Equals(input.Transcription));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsStartTranscriptionRequest {\n");
            sb.Append("  Transcription: ").Append(Transcription).Append("\n");
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
            return Equals(input as CallsStartTranscriptionRequest);
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
                if (Transcription != null)
                    hashCode = hashCode * 59 + Transcription.GetHashCode();
                return hashCode;
            }
        }
    }
}