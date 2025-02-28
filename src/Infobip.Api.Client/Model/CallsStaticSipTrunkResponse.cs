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
    ///     CallsStaticSipTrunkResponse
    /// </summary>
    [DataContract(Name = "CallsStaticSipTrunkResponse")]
    [JsonObject]
    public class CallsStaticSipTrunkResponse : CallsSipTrunkResponse, IEquatable<CallsStaticSipTrunkResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsStaticSipTrunkResponse" /> class.
        /// </summary>
        /// <param name="sourceHosts">List of source hosts..</param>
        /// <param name="destinationHosts">List of destination hosts..</param>
        /// <param name="strategy">strategy.</param>
        /// <param name="id">SIP trunk ID..</param>
        /// <param name="type">type (default to CallsSipTrunkType.Static).</param>
        /// <param name="name">SIP trunk name..</param>
        /// <param name="location">SIP trunk location..</param>
        /// <param name="tls">Indicates whether communication is secured by the TLS protocol..</param>
        /// <param name="codecs">List of audio codecs supported by a SIP trunk..</param>
        /// <param name="dtmf">dtmf.</param>
        /// <param name="fax">fax.</param>
        /// <param name="numberFormat">numberFormat.</param>
        /// <param name="internationalCallsAllowed">
        ///     Indicates whether international calls should be allowed. Calls between
        ///     different countries are considered international..
        /// </param>
        /// <param name="channelLimit">Maximum number of concurrent channels..</param>
        /// <param name="anonymization">anonymization.</param>
        /// <param name="billingPackage">billingPackage.</param>
        /// <param name="sbcHosts">sbcHosts.</param>
        /// <param name="sipOptions">sipOptions.</param>
        public CallsStaticSipTrunkResponse(List<string> sourceHosts = default, List<string> destinationHosts = default,
            CallsSelectionStrategy? strategy = default, string id = default,
            CallsSipTrunkType? type = CallsSipTrunkType.Static, string name = default, string location = default,
            bool tls = default, List<CallsAudioCodec> codecs = default, CallsDtmfType? dtmf = default,
            CallsFaxType? fax = default, CallsNumberPresentationFormat? numberFormat = default,
            bool internationalCallsAllowed = default, int channelLimit = default,
            CallsAnonymizationType? anonymization = default, CallsBillingPackage billingPackage = default,
            CallsSbcHosts sbcHosts = default, CallsSipOptions sipOptions = default) : base(id, type, name, location,
            tls, codecs, dtmf, fax, numberFormat, internationalCallsAllowed, channelLimit, anonymization,
            billingPackage, sbcHosts, sipOptions)
        {
            SourceHosts = sourceHosts;
            DestinationHosts = destinationHosts;
            Strategy = strategy;
        }

        /// <summary>
        ///     Gets or Sets Strategy
        /// </summary>
        [DataMember(Name = "strategy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "strategy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("strategy")]
        public CallsSelectionStrategy? Strategy { get; set; }

        /// <summary>
        ///     List of source hosts.
        /// </summary>
        /// <value>List of source hosts.</value>
        [DataMember(Name = "sourceHosts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sourceHosts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sourceHosts")]
        public List<string> SourceHosts { get; set; }

        /// <summary>
        ///     List of destination hosts.
        /// </summary>
        /// <value>List of destination hosts.</value>
        [DataMember(Name = "destinationHosts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "destinationHosts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("destinationHosts")]
        public List<string> DestinationHosts { get; set; }

        /// <summary>
        ///     Returns true if CallsStaticSipTrunkResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsStaticSipTrunkResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsStaticSipTrunkResponse input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       SourceHosts == input.SourceHosts ||
                       (SourceHosts != null &&
                        input.SourceHosts != null &&
                        SourceHosts.SequenceEqual(input.SourceHosts))
                   ) && base.Equals(input) &&
                   (
                       DestinationHosts == input.DestinationHosts ||
                       (DestinationHosts != null &&
                        input.DestinationHosts != null &&
                        DestinationHosts.SequenceEqual(input.DestinationHosts))
                   ) && base.Equals(input) &&
                   (
                       Strategy == input.Strategy ||
                       Strategy.Equals(input.Strategy)
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsStaticSipTrunkResponse {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SourceHosts: ").Append(SourceHosts).Append("\n");
            sb.Append("  DestinationHosts: ").Append(DestinationHosts).Append("\n");
            sb.Append("  Strategy: ").Append(Strategy).Append("\n");
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
            return Equals(input as CallsStaticSipTrunkResponse);
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
                if (SourceHosts != null)
                    hashCode = hashCode * 59 + SourceHosts.GetHashCode();
                if (DestinationHosts != null)
                    hashCode = hashCode * 59 + DestinationHosts.GetHashCode();
                hashCode = hashCode * 59 + Strategy.GetHashCode();
                return hashCode;
            }
        }
    }
}