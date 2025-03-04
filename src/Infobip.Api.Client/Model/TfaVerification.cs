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
    ///     TfaVerification
    /// </summary>
    [DataContract(Name = "TfaVerification")]
    [JsonObject]
    public class TfaVerification : IEquatable<TfaVerification>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaVerification" /> class.
        /// </summary>
        /// <param name="msisdn">Phone number (MSISDN) for which verification status is checked..</param>
        /// <param name="sentAt">Sent UNIX timestamp (in millis), if the phone number (MSISDN) is verified..</param>
        /// <param name="verified">Indicates if the phone number (MSISDN) is already verified for 2FA application with given ID..</param>
        /// <param name="verifiedAt">Verification UNIX timestamp (in millis), if the phone number (MSISDN) is verified..</param>
        public TfaVerification(string msisdn = default, long sentAt = default, bool verified = default,
            long verifiedAt = default)
        {
            Msisdn = msisdn;
            SentAt = sentAt;
            Verified = verified;
            VerifiedAt = verifiedAt;
        }

        /// <summary>
        ///     Phone number (MSISDN) for which verification status is checked.
        /// </summary>
        /// <value>Phone number (MSISDN) for which verification status is checked.</value>
        [DataMember(Name = "msisdn", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "msisdn", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        ///     Sent UNIX timestamp (in millis), if the phone number (MSISDN) is verified.
        /// </summary>
        /// <value>Sent UNIX timestamp (in millis), if the phone number (MSISDN) is verified.</value>
        [DataMember(Name = "sentAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sentAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sentAt")]
        public long SentAt { get; set; }

        /// <summary>
        ///     Indicates if the phone number (MSISDN) is already verified for 2FA application with given ID.
        /// </summary>
        /// <value>Indicates if the phone number (MSISDN) is already verified for 2FA application with given ID.</value>
        [DataMember(Name = "verified", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "verified", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        /// <summary>
        ///     Verification UNIX timestamp (in millis), if the phone number (MSISDN) is verified.
        /// </summary>
        /// <value>Verification UNIX timestamp (in millis), if the phone number (MSISDN) is verified.</value>
        [DataMember(Name = "verifiedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "verifiedAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("verifiedAt")]
        public long VerifiedAt { get; set; }

        /// <summary>
        ///     Returns true if TfaVerification instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaVerification to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaVerification input)
        {
            if (input == null)
                return false;

            return
                (
                    Msisdn == input.Msisdn ||
                    (Msisdn != null &&
                     Msisdn.Equals(input.Msisdn))
                ) &&
                (
                    SentAt == input.SentAt ||
                    SentAt.Equals(input.SentAt)
                ) &&
                (
                    Verified == input.Verified ||
                    Verified.Equals(input.Verified)
                ) &&
                (
                    VerifiedAt == input.VerifiedAt ||
                    VerifiedAt.Equals(input.VerifiedAt)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaVerification {\n");
            sb.Append("  Msisdn: ").Append(Msisdn).Append("\n");
            sb.Append("  SentAt: ").Append(SentAt).Append("\n");
            sb.Append("  Verified: ").Append(Verified).Append("\n");
            sb.Append("  VerifiedAt: ").Append(VerifiedAt).Append("\n");
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
            return Equals(input as TfaVerification);
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
                if (Msisdn != null)
                    hashCode = hashCode * 59 + Msisdn.GetHashCode();
                hashCode = hashCode * 59 + SentAt.GetHashCode();
                hashCode = hashCode * 59 + Verified.GetHashCode();
                hashCode = hashCode * 59 + VerifiedAt.GetHashCode();
                return hashCode;
            }
        }
    }
}