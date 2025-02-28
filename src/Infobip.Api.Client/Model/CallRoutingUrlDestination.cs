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
    ///     CallRoutingUrlDestination
    /// </summary>
    [DataContract(Name = "CallRoutingUrlDestination")]
    [JsonObject]
    public class CallRoutingUrlDestination : CallRoutingDestination, IEquatable<CallRoutingUrlDestination>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingUrlDestination" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallRoutingUrlDestination()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingUrlDestination" /> class.
        /// </summary>
        /// <param name="url">
        ///     URL endpoint which provides next destination to be tried in a route as a response to &#x60;POST&#x60;
        ///     HTTP request sent by the Infobip Platform. Returned destination must be of &#x60;ENDPOINT_DESTINATION&#x60; type.
        ///     (required).
        /// </param>
        /// <param name="securityConfig">securityConfig.</param>
        /// <param name="priority">
        ///     Priority of the destination within a route. Destinations with lower value have higher priority.
        ///     Either all or no destination need to have this value defined..
        /// </param>
        /// <param name="type">type (required) (default to CallRoutingDestinationType.Url).</param>
        /// <param name="weight">
        ///     Weight of the destination within a route. It specifies how much traffic is handled by destination
        ///     relative to other destinations within the same priority level. Values are evaluated relative to each other and they
        ///     don&#39;t need to add up to 100. Either all or no destination need to have this value defined..
        /// </param>
        public CallRoutingUrlDestination(string url = default, SecurityConfig securityConfig = default,
            int priority = default, CallRoutingDestinationType type = CallRoutingDestinationType.Url,
            int weight = default) : base(priority, type, weight)
        {
            // to ensure "url" is required (not null)
            Url = url ?? throw new ArgumentNullException("url");
            SecurityConfig = securityConfig;
        }

        /// <summary>
        ///     URL endpoint which provides next destination to be tried in a route as a response to &#x60;POST&#x60; HTTP request
        ///     sent by the Infobip Platform. Returned destination must be of &#x60;ENDPOINT_DESTINATION&#x60; type.
        /// </summary>
        /// <value>
        ///     URL endpoint which provides next destination to be tried in a route as a response to &#x60;POST&#x60; HTTP
        ///     request sent by the Infobip Platform. Returned destination must be of &#x60;ENDPOINT_DESTINATION&#x60; type.
        /// </value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "url", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or Sets SecurityConfig
        /// </summary>
        [DataMember(Name = "securityConfig", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "securityConfig", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("securityConfig")]
        public SecurityConfig SecurityConfig { get; set; }

        /// <summary>
        ///     Returns true if CallRoutingUrlDestination instances are equal
        /// </summary>
        /// <param name="input">Instance of CallRoutingUrlDestination to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallRoutingUrlDestination input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       Url == input.Url ||
                       (Url != null &&
                        Url.Equals(input.Url))
                   ) && base.Equals(input) &&
                   (
                       SecurityConfig == input.SecurityConfig ||
                       (SecurityConfig != null &&
                        SecurityConfig.Equals(input.SecurityConfig))
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallRoutingUrlDestination {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  SecurityConfig: ").Append(SecurityConfig).Append("\n");
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
            return Equals(input as CallRoutingUrlDestination);
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
                if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                if (SecurityConfig != null)
                    hashCode = hashCode * 59 + SecurityConfig.GetHashCode();
                return hashCode;
            }
        }
    }
}