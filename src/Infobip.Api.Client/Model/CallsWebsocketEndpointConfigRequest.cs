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
using Newtonsoft.Json.Converters;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallsWebsocketEndpointConfigRequest
    /// </summary>
    [DataContract(Name = "CallsWebsocketEndpointConfigRequest")]
    [JsonObject]
    public class CallsWebsocketEndpointConfigRequest : CallsMediaStreamConfigRequest,
        IEquatable<CallsWebsocketEndpointConfigRequest>
    {
        /// <summary>
        ///     Audio sampling rate..
        /// </summary>
        /// <value>Audio sampling rate.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public enum SampleRateEnum
        {
            /// <summary>
            ///     Enum 8000 for value: 8000
            /// </summary>
            [EnumMember(Value = "8000")] _8000 = 1,

            /// <summary>
            ///     Enum 16000 for value: 16000
            /// </summary>
            [EnumMember(Value = "16000")] _16000 = 2
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsWebsocketEndpointConfigRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsWebsocketEndpointConfigRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsWebsocketEndpointConfigRequest" /> class.
        /// </summary>
        /// <param name="sampleRate">Audio sampling rate. (default to SampleRateEnum.8000).</param>
        /// <param name="type">type (default to CallsRequestMediaStreamConfigType.WebsocketEndpoint).</param>
        /// <param name="name">Media-stream configuration name. (required).</param>
        /// <param name="url">Destination websocket or load balancer URL. (required).</param>
        public CallsWebsocketEndpointConfigRequest(SampleRateEnum? sampleRate = SampleRateEnum._8000,
            CallsRequestMediaStreamConfigType? type = CallsRequestMediaStreamConfigType.WebsocketEndpoint,
            string name = default, string url = default) : base(type, name, url)
        {
            SampleRate = sampleRate;
        }

        /// <summary>
        ///     Audio sampling rate.
        /// </summary>
        /// <value>Audio sampling rate.</value>
        [DataMember(Name = "sampleRate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sampleRate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("sampleRate")]
        public SampleRateEnum? SampleRate { get; set; }

        /// <summary>
        ///     Returns true if CallsWebsocketEndpointConfigRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsWebsocketEndpointConfigRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsWebsocketEndpointConfigRequest input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                   (
                       SampleRate == input.SampleRate ||
                       SampleRate.Equals(input.SampleRate)
                   );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsWebsocketEndpointConfigRequest {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  SampleRate: ").Append(SampleRate).Append("\n");
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
            return Equals(input as CallsWebsocketEndpointConfigRequest);
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
                hashCode = hashCode * 59 + SampleRate.GetHashCode();
                return hashCode;
            }
        }
    }
}