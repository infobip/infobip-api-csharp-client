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
    ///     CallsMediaStreamingConfigRequest
    /// </summary>
    [DataContract(Name = "CallsMediaStreamingConfigRequest")]
    [JsonObject]
    public class CallsMediaStreamingConfigRequest : CallsMediaStreamConfigRequest,
        IEquatable<CallsMediaStreamingConfigRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsMediaStreamingConfigRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsMediaStreamingConfigRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsMediaStreamingConfigRequest" /> class.
        /// </summary>
        /// <param name="securityConfig">securityConfig.</param>
        /// <param name="type">type (default to CallsRequestMediaStreamConfigType.MediaStreaming).</param>
        /// <param name="name">Media-stream configuration name. (required).</param>
        /// <param name="url">Destination websocket or load balancer URL. (required).</param>
        public CallsMediaStreamingConfigRequest(SecurityConfig securityConfig = default,
            CallsRequestMediaStreamConfigType? type = CallsRequestMediaStreamConfigType.MediaStreaming,
            string name = default, string url = default) : base(type, name, url)
        {
            SecurityConfig = securityConfig;
        }

        /// <summary>
        ///     Gets or Sets SecurityConfig
        /// </summary>
        [DataMember(Name = "securityConfig", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "securityConfig", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("securityConfig")]
        public SecurityConfig SecurityConfig { get; set; }

        /// <summary>
        ///     Returns true if CallsMediaStreamingConfigRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsMediaStreamingConfigRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsMediaStreamingConfigRequest input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
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
            sb.Append("class CallsMediaStreamingConfigRequest {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
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
            return Equals(input as CallsMediaStreamingConfigRequest);
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
                if (SecurityConfig != null)
                    hashCode = hashCode * 59 + SecurityConfig.GetHashCode();
                return hashCode;
            }
        }
    }
}