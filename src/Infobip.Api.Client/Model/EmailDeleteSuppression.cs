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
    ///     Suppression.
    /// </summary>
    [DataContract(Name = "EmailDeleteSuppression")]
    [JsonObject]
    public class EmailDeleteSuppression : IEquatable<EmailDeleteSuppression>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailDeleteSuppression" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EmailDeleteSuppression()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailDeleteSuppression" /> class.
        /// </summary>
        /// <param name="domainName">Domain name from which suppressions will be deleted. (required).</param>
        /// <param name="emailAddress">Email addresses that need to be deleted. (required).</param>
        /// <param name="type">type (required).</param>
        public EmailDeleteSuppression(string domainName = default, List<string> emailAddress = default,
            EmailSuppressionType type = default)
        {
            // to ensure "domainName" is required (not null)
            DomainName = domainName ?? throw new ArgumentNullException("domainName");
            // to ensure "emailAddress" is required (not null)
            EmailAddress = emailAddress ?? throw new ArgumentNullException("emailAddress");
            Type = type;
        }

        /// <summary>
        ///     Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "type", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("type")]
        public EmailSuppressionType Type { get; set; }

        /// <summary>
        ///     Domain name from which suppressions will be deleted.
        /// </summary>
        /// <value>Domain name from which suppressions will be deleted.</value>
        [DataMember(Name = "domainName", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "domainName", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("domainName")]
        public string DomainName { get; set; }

        /// <summary>
        ///     Email addresses that need to be deleted.
        /// </summary>
        /// <value>Email addresses that need to be deleted.</value>
        [DataMember(Name = "emailAddress", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "emailAddress", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("emailAddress")]
        public List<string> EmailAddress { get; set; }

        /// <summary>
        ///     Returns true if EmailDeleteSuppression instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailDeleteSuppression to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailDeleteSuppression input)
        {
            if (input == null)
                return false;

            return
                (
                    DomainName == input.DomainName ||
                    (DomainName != null &&
                     DomainName.Equals(input.DomainName))
                ) &&
                (
                    EmailAddress == input.EmailAddress ||
                    (EmailAddress != null &&
                     input.EmailAddress != null &&
                     EmailAddress.SequenceEqual(input.EmailAddress))
                ) &&
                (
                    Type == input.Type ||
                    Type.Equals(input.Type)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailDeleteSuppression {\n");
            sb.Append("  DomainName: ").Append(DomainName).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return Equals(input as EmailDeleteSuppression);
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
                if (DomainName != null)
                    hashCode = hashCode * 59 + DomainName.GetHashCode();
                if (EmailAddress != null)
                    hashCode = hashCode * 59 + EmailAddress.GetHashCode();
                hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }
    }
}