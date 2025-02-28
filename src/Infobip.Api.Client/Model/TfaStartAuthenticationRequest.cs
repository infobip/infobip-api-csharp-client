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
    ///     TfaStartAuthenticationRequest
    /// </summary>
    [DataContract(Name = "TfaStartAuthenticationRequest")]
    [JsonObject]
    public class TfaStartAuthenticationRequest : IEquatable<TfaStartAuthenticationRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaStartAuthenticationRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TfaStartAuthenticationRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaStartAuthenticationRequest" /> class.
        /// </summary>
        /// <param name="applicationId">
        ///     The ID of the application that represents your service, e.g. 2FA for login, 2FA for
        ///     changing the password, etc. (required).
        /// </param>
        /// <param name="from">
        ///     Use this parameter if you wish to override the sender ID from the
        ///     [created](#channels/sms/create-2fa-message-template) message template parameter &#x60;senderId&#x60;..
        /// </param>
        /// <param name="messageId">
        ///     The ID of the message template (message body with the PIN placeholder) that is sent to the
        ///     recipient. (required).
        /// </param>
        /// <param name="placeholders">
        ///     Key value pairs that will be replaced during message sending. Placeholder keys should NOT
        ///     contain curly brackets and should NOT contain a &#x60;pin&#x60; placeholder. Valid example: &#x60;\&quot;
        ///     placeholders\&quot;:{\&quot;firstName\&quot;:\&quot;John\&quot;}&#x60;.
        /// </param>
        /// <param name="to">Phone number to which the 2FA message will be sent. Example: 41793026727. (required).</param>
        public TfaStartAuthenticationRequest(string applicationId = default, string from = default,
            string messageId = default, Dictionary<string, string> placeholders = default, string to = default)
        {
            // to ensure "applicationId" is required (not null)
            ApplicationId = applicationId ?? throw new ArgumentNullException("applicationId");
            // to ensure "messageId" is required (not null)
            MessageId = messageId ?? throw new ArgumentNullException("messageId");
            // to ensure "to" is required (not null)
            To = to ?? throw new ArgumentNullException("to");
            From = from;
            Placeholders = placeholders;
        }

        /// <summary>
        ///     The ID of the application that represents your service, e.g. 2FA for login, 2FA for changing the password, etc.
        /// </summary>
        /// <value>The ID of the application that represents your service, e.g. 2FA for login, 2FA for changing the password, etc.</value>
        [DataMember(Name = "applicationId", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "applicationId", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("applicationId")]
        public string ApplicationId { get; set; }

        /// <summary>
        ///     Use this parameter if you wish to override the sender ID from the
        ///     [created](#channels/sms/create-2fa-message-template) message template parameter &#x60;senderId&#x60;.
        /// </summary>
        /// <value>
        ///     Use this parameter if you wish to override the sender ID from the
        ///     [created](#channels/sms/create-2fa-message-template) message template parameter &#x60;senderId&#x60;.
        /// </value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "from", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("from")]
        public string From { get; set; }

        /// <summary>
        ///     The ID of the message template (message body with the PIN placeholder) that is sent to the recipient.
        /// </summary>
        /// <value>The ID of the message template (message body with the PIN placeholder) that is sent to the recipient.</value>
        [DataMember(Name = "messageId", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "messageId", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets
        ///     and should NOT contain a &#x60;pin&#x60; placeholder. Valid example: &#x60;\&quot;placeholders\&quot;:{\&quot;
        ///     firstName\&quot;:\&quot;John\&quot;}&#x60;
        /// </summary>
        /// <value>
        ///     Key value pairs that will be replaced during message sending. Placeholder keys should NOT contain curly brackets
        ///     and should NOT contain a &#x60;pin&#x60; placeholder. Valid example: &#x60;\&quot;placeholders\&quot;:{\&quot;
        ///     firstName\&quot;:\&quot;John\&quot;}&#x60;
        /// </value>
        [DataMember(Name = "placeholders", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "placeholders", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("placeholders")]
        public Dictionary<string, string> Placeholders { get; set; }

        /// <summary>
        ///     Phone number to which the 2FA message will be sent. Example: 41793026727.
        /// </summary>
        /// <value>Phone number to which the 2FA message will be sent. Example: 41793026727.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "to", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     Returns true if TfaStartAuthenticationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaStartAuthenticationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaStartAuthenticationRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    ApplicationId == input.ApplicationId ||
                    (ApplicationId != null &&
                     ApplicationId.Equals(input.ApplicationId))
                ) &&
                (
                    From == input.From ||
                    (From != null &&
                     From.Equals(input.From))
                ) &&
                (
                    MessageId == input.MessageId ||
                    (MessageId != null &&
                     MessageId.Equals(input.MessageId))
                ) &&
                (
                    Placeholders == input.Placeholders ||
                    (Placeholders != null &&
                     input.Placeholders != null &&
                     Placeholders.SequenceEqual(input.Placeholders))
                ) &&
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaStartAuthenticationRequest {\n");
            sb.Append("  ApplicationId: ").Append(ApplicationId).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  MessageId: ").Append(MessageId).Append("\n");
            sb.Append("  Placeholders: ").Append(Placeholders).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
            return Equals(input as TfaStartAuthenticationRequest);
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
                if (ApplicationId != null)
                    hashCode = hashCode * 59 + ApplicationId.GetHashCode();
                if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                if (MessageId != null)
                    hashCode = hashCode * 59 + MessageId.GetHashCode();
                if (Placeholders != null)
                    hashCode = hashCode * 59 + Placeholders.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                return hashCode;
            }
        }
    }
}