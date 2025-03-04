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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     TfaVerificationResponse
    /// </summary>
    [DataContract(Name = "TfaVerificationResponse")]
    [JsonObject]
    public class TfaVerificationResponse : IEquatable<TfaVerificationResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaVerificationResponse" /> class.
        /// </summary>
        /// <param name="verifications">Collection of verifications.</param>
        public TfaVerificationResponse(List<TfaVerification> verifications = default)
        {
            Verifications = verifications;
        }

        /// <summary>
        ///     Collection of verifications
        /// </summary>
        /// <value>Collection of verifications</value>
        [DataMember(Name = "verifications", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "verifications", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("verifications")]
        public List<TfaVerification> Verifications { get; set; }

        /// <summary>
        ///     Returns true if TfaVerificationResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaVerificationResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaVerificationResponse input)
        {
            if (input == null)
                return false;

            return
                Verifications == input.Verifications ||
                (Verifications != null &&
                 input.Verifications != null &&
                 Verifications.SequenceEqual(input.Verifications));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaVerificationResponse {\n");
            sb.Append("  Verifications: ").Append(Verifications).Append("\n");
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
            return Equals(input as TfaVerificationResponse);
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
                if (Verifications != null)
                    hashCode = hashCode * 59 + Verifications.GetHashCode();
                return hashCode;
            }
        }
    }
}