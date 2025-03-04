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
    [DataContract(Name = "EmailAddSuppression")]
    [JsonObject]
    public class EmailAddSuppression : IEquatable<EmailAddSuppression>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddSuppression" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EmailAddSuppression()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddSuppression" /> class.
        /// </summary>
        /// <param name="domainName">Domain name from which suppressions will be added. (required).</param>
        /// <param name="emailAddress">Email addresses to add to suppression list. (required).</param>
        /// <param name="type">type (required).</param>
        public EmailAddSuppression(string domainName = default, List<string> emailAddress = default,
            EmailAddSuppressionType type = default)
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
        public EmailAddSuppressionType Type { get; set; }

        /// <summary>
        ///     Domain name from which suppressions will be added.
        /// </summary>
        /// <value>Domain name from which suppressions will be added.</value>
        [DataMember(Name = "domainName", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "domainName", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("domainName")]
        public string DomainName { get; set; }

        /// <summary>
        ///     Email addresses to add to suppression list.
        /// </summary>
        /// <value>Email addresses to add to suppression list.</value>
        [DataMember(Name = "emailAddress", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "emailAddress", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("emailAddress")]
        public List<string> EmailAddress { get; set; }

        /// <summary>
        ///     Returns true if EmailAddSuppression instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailAddSuppression to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailAddSuppression input)
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
            sb.Append("class EmailAddSuppression {\n");
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
            return Equals(input as EmailAddSuppression);
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