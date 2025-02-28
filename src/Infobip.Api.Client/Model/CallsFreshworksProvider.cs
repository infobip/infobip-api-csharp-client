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
    ///     CallsFreshworksProvider
    /// </summary>
    [DataContract(Name = "CallsFreshworksProvider")]
    [JsonObject]
    public class CallsFreshworksProvider : CallsProvider, IEquatable<CallsFreshworksProvider>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsFreshworksProvider" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsFreshworksProvider()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsFreshworksProvider" /> class.
        /// </summary>
        /// <param name="accountSid">Twilio account sid of the trunk. (required).</param>
        /// <param name="sipDomain">Sip domain related to the trunk. (required).</param>
        /// <param name="type">type (default to CallsProviderTrunkType.Freshworks).</param>
        public CallsFreshworksProvider(string accountSid = default, string sipDomain = default,
            CallsProviderTrunkType? type = CallsProviderTrunkType.Freshworks) : base(type)
        {
            // to ensure "accountSid" is required (not null)
            AccountSid = accountSid ?? throw new ArgumentNullException("accountSid");
            // to ensure "sipDomain" is required (not null)
            SipDomain = sipDomain ?? throw new ArgumentNullException("sipDomain");
        }

        /// <summary>
        ///     Twilio account sid of the trunk.
        /// </summary>
        /// <value>Twilio account sid of the trunk.</value>
        [DataMember(Name = "accountSid", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "accountSid", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("accountSid")]
        public string AccountSid { get; set; }

        /// <summary>
        ///     Sip domain related to the trunk.
        /// </summary>
        /// <value>Sip domain related to the trunk.</value>
        [DataMember(Name = "sipDomain", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "sipDomain", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("sipDomain")]
        public string SipDomain { get; set; }

        /// <summary>
        ///     Returns true if CallsFreshworksProvider instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsFreshworksProvider to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsFreshworksProvider input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       AccountSid == input.AccountSid ||
                       (AccountSid != null &&
                        AccountSid.Equals(input.AccountSid))
                   ) && base.Equals(input) &&
                   (
                       SipDomain == input.SipDomain ||
                       (SipDomain != null &&
                        SipDomain.Equals(input.SipDomain))
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsFreshworksProvider {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  AccountSid: ").Append(AccountSid).Append("\n");
            sb.Append("  SipDomain: ").Append(SipDomain).Append("\n");
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
            return Equals(input as CallsFreshworksProvider);
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
                if (AccountSid != null)
                    hashCode = hashCode * 59 + AccountSid.GetHashCode();
                if (SipDomain != null)
                    hashCode = hashCode * 59 + SipDomain.GetHashCode();
                return hashCode;
            }
        }
    }
}