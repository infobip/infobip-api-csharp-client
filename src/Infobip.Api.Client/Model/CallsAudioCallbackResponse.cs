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
    ///     CallsAudioCallbackResponse
    /// </summary>
    [DataContract(Name = "CallsAudioCallbackResponse")]
    [JsonObject]
    public class CallsAudioCallbackResponse : CallbackResponse, IEquatable<CallsAudioCallbackResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAudioCallbackResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsAudioCallbackResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAudioCallbackResponse" /> class.
        /// </summary>
        /// <param name="fileUrl">
        ///     Url of the audio file to be played to the caller. Required if &#x60;fileId&#x60; is not
        ///     provided..
        /// </param>
        /// <param name="fileId">
        ///     Identification of the audio file to be played to the caller. Required if &#x60;fileUrl&#x60; is
        ///     not provided..
        /// </param>
        /// <param name="command">command (required) (default to &quot;audio&quot;).</param>
        public CallsAudioCallbackResponse(string fileUrl = default, string fileId = default, string command = "audio") :
            base(command)
        {
            FileUrl = fileUrl;
            FileId = fileId;
        }

        /// <summary>
        ///     Url of the audio file to be played to the caller. Required if &#x60;fileId&#x60; is not provided.
        /// </summary>
        /// <value>Url of the audio file to be played to the caller. Required if &#x60;fileId&#x60; is not provided.</value>
        [DataMember(Name = "fileUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fileUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("fileUrl")]
        public string FileUrl { get; set; }

        /// <summary>
        ///     Identification of the audio file to be played to the caller. Required if &#x60;fileUrl&#x60; is not provided.
        /// </summary>
        /// <value>Identification of the audio file to be played to the caller. Required if &#x60;fileUrl&#x60; is not provided.</value>
        [DataMember(Name = "fileId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fileId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("fileId")]
        public string FileId { get; set; }

        /// <summary>
        ///     Returns true if CallsAudioCallbackResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsAudioCallbackResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsAudioCallbackResponse input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       FileUrl == input.FileUrl ||
                       (FileUrl != null &&
                        FileUrl.Equals(input.FileUrl))
                   ) && base.Equals(input) &&
                   (
                       FileId == input.FileId ||
                       (FileId != null &&
                        FileId.Equals(input.FileId))
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsAudioCallbackResponse {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  FileUrl: ").Append(FileUrl).Append("\n");
            sb.Append("  FileId: ").Append(FileId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return Equals(input as CallsAudioCallbackResponse);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = base.GetHashCode();
                if (FileUrl != null)
                    hashCode = hashCode * 59 + FileUrl.GetHashCode();
                if (FileId != null)
                    hashCode = hashCode * 59 + FileId.GetHashCode();
                return hashCode;
            }
        }
    }
}