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
    ///     CallsMultiBody
    /// </summary>
    [DataContract(Name = "CallsMultiBody")]
    [JsonObject]
    public class CallsMultiBody : IEquatable<CallsMultiBody>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsMultiBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsMultiBody()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsMultiBody" /> class.
        /// </summary>
        /// <param name="messages">Array of messages to be sent, one per every message. (required).</param>
        public CallsMultiBody(List<CallsMultiMessage> messages = default)
        {
            // to ensure "messages" is required (not null)
            Messages = messages ?? throw new ArgumentNullException("messages");
        }

        /// <summary>
        ///     Array of messages to be sent, one per every message.
        /// </summary>
        /// <value>Array of messages to be sent, one per every message.</value>
        [DataMember(Name = "messages", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "messages", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("messages")]
        public List<CallsMultiMessage> Messages { get; set; }

        /// <summary>
        ///     Returns true if CallsMultiBody instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsMultiBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsMultiBody input)
        {
            if (input == null)
                return false;

            return
                Messages == input.Messages ||
                (Messages != null &&
                 input.Messages != null &&
                 Messages.SequenceEqual(input.Messages));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsMultiBody {\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
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
            return Equals(input as CallsMultiBody);
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
                if (Messages != null)
                    hashCode = hashCode * 59 + Messages.GetHashCode();
                return hashCode;
            }
        }
    }
}