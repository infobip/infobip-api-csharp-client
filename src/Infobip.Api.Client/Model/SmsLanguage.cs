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
    ///     Sets the language parameters for the message being sent.
    /// </summary>
    [DataContract(Name = "SmsLanguage")]
    [JsonObject]
    public class SmsLanguage : IEquatable<SmsLanguage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsLanguage" /> class.
        /// </summary>
        /// <param name="languageCode">languageCode.</param>
        /// <param name="singleShift">
        ///     Uses a single shift table which enhances only the extension table of the GSM default
        ///     alphabet. Allows you to selectively improve character support without altering the entire message. (default to
        ///     false).
        /// </param>
        /// <param name="lockingShift">
        ///     Uses a locking shift table which allows you to represent characters beyond the standard GSM
        ///     default alphabet. This flexibility enables better language support. (default to false).
        /// </param>
        public SmsLanguage(SmsLanguageCode? languageCode = default, bool singleShift = false, bool lockingShift = false)
        {
            LanguageCode = languageCode;
            SingleShift = singleShift;
            LockingShift = lockingShift;
        }

        /// <summary>
        ///     Gets or Sets LanguageCode
        /// </summary>
        [DataMember(Name = "languageCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "languageCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("languageCode")]
        public SmsLanguageCode? LanguageCode { get; set; }

        /// <summary>
        ///     Uses a single shift table which enhances only the extension table of the GSM default alphabet. Allows you to
        ///     selectively improve character support without altering the entire message.
        /// </summary>
        /// <value>
        ///     Uses a single shift table which enhances only the extension table of the GSM default alphabet. Allows you to
        ///     selectively improve character support without altering the entire message.
        /// </value>
        [DataMember(Name = "singleShift", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "singleShift", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("singleShift")]
        public bool SingleShift { get; set; }

        /// <summary>
        ///     Uses a locking shift table which allows you to represent characters beyond the standard GSM default alphabet. This
        ///     flexibility enables better language support.
        /// </summary>
        /// <value>
        ///     Uses a locking shift table which allows you to represent characters beyond the standard GSM default alphabet.
        ///     This flexibility enables better language support.
        /// </value>
        [DataMember(Name = "lockingShift", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "lockingShift", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("lockingShift")]
        public bool LockingShift { get; set; }

        /// <summary>
        ///     Returns true if SmsLanguage instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsLanguage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsLanguage input)
        {
            if (input == null)
                return false;

            return
                (
                    LanguageCode == input.LanguageCode ||
                    LanguageCode.Equals(input.LanguageCode)
                ) &&
                (
                    SingleShift == input.SingleShift ||
                    SingleShift.Equals(input.SingleShift)
                ) &&
                (
                    LockingShift == input.LockingShift ||
                    LockingShift.Equals(input.LockingShift)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsLanguage {\n");
            sb.Append("  LanguageCode: ").Append(LanguageCode).Append("\n");
            sb.Append("  SingleShift: ").Append(SingleShift).Append("\n");
            sb.Append("  LockingShift: ").Append(LockingShift).Append("\n");
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
            return Equals(input as SmsLanguage);
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
                hashCode = hashCode * 59 + LanguageCode.GetHashCode();
                hashCode = hashCode * 59 + SingleShift.GetHashCode();
                hashCode = hashCode * 59 + LockingShift.GetHashCode();
                return hashCode;
            }
        }
    }
}