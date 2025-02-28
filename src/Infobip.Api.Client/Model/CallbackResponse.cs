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
using JsonSubTypes;
using Newtonsoft.Json;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallbackResponse
    /// </summary>
    [DataContract(Name = "CallbackResponse")]
    [JsonObject]
    [JsonConverter(typeof(JsonSubtypes), "Command")]
    [JsonSubtypes.KnownSubType(typeof(CallsAudioCallbackResponse), "audio")]
    [JsonSubtypes.KnownSubType(typeof(CallsCaptureDtmfCallbackResponse), "captureDtmf")]
    [JsonSubtypes.KnownSubType(typeof(CallsDialCallbackResponse), "dial")]
    public class CallbackResponse : IEquatable<CallbackResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallbackResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallbackResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallbackResponse" /> class.
        /// </summary>
        /// <param name="command">command (required).</param>
        public CallbackResponse(string command = default)
        {
            // to ensure "command" is required (not null)
            Command = command ?? throw new ArgumentNullException("command");
        }

        /// <summary>
        ///     Gets or Sets Command
        /// </summary>
        [DataMember(Name = "command", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "command", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("command")]
        public string Command { get; set; }

        /// <summary>
        ///     Returns true if CallbackResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallbackResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallbackResponse input)
        {
            if (input == null)
                return false;

            return
                Command == input.Command ||
                (Command != null &&
                 Command.Equals(input.Command));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallbackResponse {\n");
            sb.Append("  Command: ").Append(Command).Append("\n");
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
            return Equals(input as CallbackResponse);
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
                if (Command != null)
                    hashCode = hashCode * 59 + Command.GetHashCode();
                return hashCode;
            }
        }
    }
}