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
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Suppressions request.
    /// </summary>
    [DataContract(Name = "EmailDeleteSuppressionRequest")]
    [JsonObject]
    public class EmailDeleteSuppressionRequest : IEquatable<EmailDeleteSuppressionRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailDeleteSuppressionRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EmailDeleteSuppressionRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailDeleteSuppressionRequest" /> class.
        /// </summary>
        /// <param name="suppressions">
        ///     Email addresses to delete from the suppression list. Number of destinations cannot exceed
        ///     10,000. (required).
        /// </param>
        public EmailDeleteSuppressionRequest(List<EmailDeleteSuppression> suppressions = default)
        {
            // to ensure "suppressions" is required (not null)
            Suppressions = suppressions ?? throw new ArgumentNullException("suppressions");
        }

        /// <summary>
        ///     Email addresses to delete from the suppression list. Number of destinations cannot exceed 10,000.
        /// </summary>
        /// <value>Email addresses to delete from the suppression list. Number of destinations cannot exceed 10,000.</value>
        [DataMember(Name = "suppressions", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "suppressions", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("suppressions")]
        public List<EmailDeleteSuppression> Suppressions { get; set; }

        /// <summary>
        ///     Returns true if EmailDeleteSuppressionRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailDeleteSuppressionRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailDeleteSuppressionRequest input)
        {
            if (input == null)
                return false;

            return
                Suppressions == input.Suppressions ||
                (Suppressions != null &&
                 input.Suppressions != null &&
                 Suppressions.SequenceEqual(input.Suppressions));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailDeleteSuppressionRequest {\n");
            sb.Append("  Suppressions: ").Append(Suppressions).Append("\n");
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
            return Equals(input as EmailDeleteSuppressionRequest);
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
                if (Suppressions != null)
                    hashCode = hashCode * 59 + Suppressions.GetHashCode();
                return hashCode;
            }
        }
    }
}