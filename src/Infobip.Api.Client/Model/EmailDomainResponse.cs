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
    ///     Detailed domain information.
    /// </summary>
    [DataContract(Name = "EmailDomainResponse")]
    [JsonObject]
    public class EmailDomainResponse : IEquatable<EmailDomainResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailDomainResponse" /> class.
        /// </summary>
        /// <param name="domainId">Id of the domain..</param>
        /// <param name="domainName">Name of the domain..</param>
        /// <param name="active">Activation status of the domain..</param>
        /// <param name="tracking">tracking.</param>
        /// <param name="dnsRecords">DNS records for the domain..</param>
        /// <param name="blocked">Status if the domain is blocked..</param>
        /// <param name="createdAt">
        ///     Date the domain was created. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ
        ///     &#x60;..
        /// </param>
        /// <param name="returnPathAddress">Mailbox for return path..</param>
        public EmailDomainResponse(long domainId = default, string domainName = default, bool active = default,
            EmailTrackingResponse tracking = default, List<EmailDnsRecordResponse> dnsRecords = default,
            bool blocked = default, DateTimeOffset createdAt = default, string returnPathAddress = default)
        {
            DomainId = domainId;
            DomainName = domainName;
            Active = active;
            Tracking = tracking;
            DnsRecords = dnsRecords;
            Blocked = blocked;
            CreatedAt = createdAt;
            ReturnPathAddress = returnPathAddress;
        }

        /// <summary>
        ///     Id of the domain.
        /// </summary>
        /// <value>Id of the domain.</value>
        [DataMember(Name = "domainId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "domainId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("domainId")]
        public long DomainId { get; set; }

        /// <summary>
        ///     Name of the domain.
        /// </summary>
        /// <value>Name of the domain.</value>
        [DataMember(Name = "domainName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "domainName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("domainName")]
        public string DomainName { get; set; }

        /// <summary>
        ///     Activation status of the domain.
        /// </summary>
        /// <value>Activation status of the domain.</value>
        [DataMember(Name = "active", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "active", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        ///     Gets or Sets Tracking
        /// </summary>
        [DataMember(Name = "tracking", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tracking", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("tracking")]
        public EmailTrackingResponse Tracking { get; set; }

        /// <summary>
        ///     DNS records for the domain.
        /// </summary>
        /// <value>DNS records for the domain.</value>
        [DataMember(Name = "dnsRecords", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "dnsRecords", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("dnsRecords")]
        public List<EmailDnsRecordResponse> DnsRecords { get; set; }

        /// <summary>
        ///     Status if the domain is blocked.
        /// </summary>
        /// <value>Status if the domain is blocked.</value>
        [DataMember(Name = "blocked", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "blocked", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }

        /// <summary>
        ///     Date the domain was created. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.
        /// </summary>
        /// <value>Date the domain was created. Has the following format: &#x60;yyyy-MM-dd&#39;T&#39;HH:mm:ss.SSSZ&#x60;.</value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "createdAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("createdAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        ///     Mailbox for return path.
        /// </summary>
        /// <value>Mailbox for return path.</value>
        [DataMember(Name = "returnPathAddress", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "returnPathAddress", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("returnPathAddress")]
        public string ReturnPathAddress { get; set; }

        /// <summary>
        ///     Returns true if EmailDomainResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailDomainResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailDomainResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    DomainId == input.DomainId ||
                    DomainId.Equals(input.DomainId)
                ) &&
                (
                    DomainName == input.DomainName ||
                    (DomainName != null &&
                     DomainName.Equals(input.DomainName))
                ) &&
                (
                    Active == input.Active ||
                    Active.Equals(input.Active)
                ) &&
                (
                    Tracking == input.Tracking ||
                    (Tracking != null &&
                     Tracking.Equals(input.Tracking))
                ) &&
                (
                    DnsRecords == input.DnsRecords ||
                    (DnsRecords != null &&
                     input.DnsRecords != null &&
                     DnsRecords.SequenceEqual(input.DnsRecords))
                ) &&
                (
                    Blocked == input.Blocked ||
                    Blocked.Equals(input.Blocked)
                ) &&
                (
                    CreatedAt == input.CreatedAt ||
                    (CreatedAt != null &&
                     CreatedAt.Equals(input.CreatedAt))
                ) &&
                (
                    ReturnPathAddress == input.ReturnPathAddress ||
                    (ReturnPathAddress != null &&
                     ReturnPathAddress.Equals(input.ReturnPathAddress))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailDomainResponse {\n");
            sb.Append("  DomainId: ").Append(DomainId).Append("\n");
            sb.Append("  DomainName: ").Append(DomainName).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Tracking: ").Append(Tracking).Append("\n");
            sb.Append("  DnsRecords: ").Append(DnsRecords).Append("\n");
            sb.Append("  Blocked: ").Append(Blocked).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  ReturnPathAddress: ").Append(ReturnPathAddress).Append("\n");
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
            return Equals(input as EmailDomainResponse);
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
                hashCode = hashCode * 59 + DomainId.GetHashCode();
                if (DomainName != null)
                    hashCode = hashCode * 59 + DomainName.GetHashCode();
                hashCode = hashCode * 59 + Active.GetHashCode();
                if (Tracking != null)
                    hashCode = hashCode * 59 + Tracking.GetHashCode();
                if (DnsRecords != null)
                    hashCode = hashCode * 59 + DnsRecords.GetHashCode();
                hashCode = hashCode * 59 + Blocked.GetHashCode();
                if (CreatedAt != null)
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                if (ReturnPathAddress != null)
                    hashCode = hashCode * 59 + ReturnPathAddress.GetHashCode();
                return hashCode;
            }
        }
    }
}