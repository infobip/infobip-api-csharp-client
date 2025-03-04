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
    ///     Announcement to be played to a caller before they dial in to the callee.
    /// </summary>
    [DataContract(Name = "CallsAnnouncementCaller")]
    [JsonObject]
    public class CallsAnnouncementCaller : IEquatable<CallsAnnouncementCaller>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsAnnouncementCaller" /> class.
        /// </summary>
        /// <param name="fileId">ID of an audio file to be played to a caller. Required if &#x60;fileUrl&#x60; is not provided..</param>
        /// <param name="fileUrl">URL of a file played to a caller. Required if &#x60;fileId&#x60; is not provided..</param>
        public CallsAnnouncementCaller(string fileId = default, string fileUrl = default)
        {
            FileId = fileId;
            FileUrl = fileUrl;
        }

        /// <summary>
        ///     ID of an audio file to be played to a caller. Required if &#x60;fileUrl&#x60; is not provided.
        /// </summary>
        /// <value>ID of an audio file to be played to a caller. Required if &#x60;fileUrl&#x60; is not provided.</value>
        [DataMember(Name = "fileId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fileId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("fileId")]
        public string FileId { get; set; }

        /// <summary>
        ///     URL of a file played to a caller. Required if &#x60;fileId&#x60; is not provided.
        /// </summary>
        /// <value>URL of a file played to a caller. Required if &#x60;fileId&#x60; is not provided.</value>
        [DataMember(Name = "fileUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fileUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("fileUrl")]
        public string FileUrl { get; set; }

        /// <summary>
        ///     Returns true if CallsAnnouncementCaller instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsAnnouncementCaller to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsAnnouncementCaller input)
        {
            if (input == null)
                return false;

            return
                (
                    FileId == input.FileId ||
                    (FileId != null &&
                     FileId.Equals(input.FileId))
                ) &&
                (
                    FileUrl == input.FileUrl ||
                    (FileUrl != null &&
                     FileUrl.Equals(input.FileUrl))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsAnnouncementCaller {\n");
            sb.Append("  FileId: ").Append(FileId).Append("\n");
            sb.Append("  FileUrl: ").Append(FileUrl).Append("\n");
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
            return Equals(input as CallsAnnouncementCaller);
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
                if (FileId != null)
                    hashCode = hashCode * 59 + FileId.GetHashCode();
                if (FileUrl != null)
                    hashCode = hashCode * 59 + FileUrl.GetHashCode();
                return hashCode;
            }
        }
    }
}