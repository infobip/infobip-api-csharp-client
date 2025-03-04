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
    ///     NumberMaskingUploadResponse
    /// </summary>
    [DataContract(Name = "NumberMaskingUploadResponse")]
    [JsonObject]
    public class NumberMaskingUploadResponse : IEquatable<NumberMaskingUploadResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingUploadResponse" /> class.
        /// </summary>
        /// <param name="fileId">Id of the uploaded audio file..</param>
        public NumberMaskingUploadResponse(string fileId = default)
        {
            FileId = fileId;
        }

        /// <summary>
        ///     Id of the uploaded audio file.
        /// </summary>
        /// <value>Id of the uploaded audio file.</value>
        [DataMember(Name = "fileId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fileId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("fileId")]
        public string FileId { get; set; }

        /// <summary>
        ///     Returns true if NumberMaskingUploadResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of NumberMaskingUploadResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NumberMaskingUploadResponse input)
        {
            if (input == null)
                return false;

            return
                FileId == input.FileId ||
                (FileId != null &&
                 FileId.Equals(input.FileId));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NumberMaskingUploadResponse {\n");
            sb.Append("  FileId: ").Append(FileId).Append("\n");
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
            return Equals(input as NumberMaskingUploadResponse);
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
                return hashCode;
            }
        }
    }
}