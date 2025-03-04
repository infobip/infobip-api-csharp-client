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

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Allows for previewing the original message content once additional language configuration has been applied to it.
    /// </summary>
    [DataContract(Name = "SmsPreview")]
    [JsonObject]
    public class SmsPreview : IEquatable<SmsPreview>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsPreview" /> class.
        /// </summary>
        /// <param name="textPreview">Preview of the message content as it should appear on the recipient’s device..</param>
        /// <param name="messageCount">Number of SMS message parts required to deliver the message..</param>
        /// <param name="charactersRemaining">Number of remaining characters in the last part of the SMS..</param>
        /// <param name="varConfiguration">varConfiguration.</param>
        public SmsPreview(string textPreview = default, int messageCount = default, int charactersRemaining = default,
            SmsLanguageConfiguration varConfiguration = default)
        {
            TextPreview = textPreview;
            MessageCount = messageCount;
            CharactersRemaining = charactersRemaining;
            VarConfiguration = varConfiguration;
        }

        /// <summary>
        ///     Preview of the message content as it should appear on the recipient’s device.
        /// </summary>
        /// <value>Preview of the message content as it should appear on the recipient’s device.</value>
        [DataMember(Name = "textPreview", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "textPreview", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("textPreview")]
        public string TextPreview { get; set; }

        /// <summary>
        ///     Number of SMS message parts required to deliver the message.
        /// </summary>
        /// <value>Number of SMS message parts required to deliver the message.</value>
        [DataMember(Name = "messageCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "messageCount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("messageCount")]
        public int MessageCount { get; set; }

        /// <summary>
        ///     Number of remaining characters in the last part of the SMS.
        /// </summary>
        /// <value>Number of remaining characters in the last part of the SMS.</value>
        [DataMember(Name = "charactersRemaining", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "charactersRemaining", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("charactersRemaining")]
        public int CharactersRemaining { get; set; }

        /// <summary>
        ///     Gets or Sets VarConfiguration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "configuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("configuration")]
        public SmsLanguageConfiguration VarConfiguration { get; set; }

        /// <summary>
        ///     Returns true if SmsPreview instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsPreview to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsPreview input)
        {
            if (input == null)
                return false;

            return
                (
                    TextPreview == input.TextPreview ||
                    (TextPreview != null &&
                     TextPreview.Equals(input.TextPreview))
                ) &&
                (
                    MessageCount == input.MessageCount ||
                    MessageCount.Equals(input.MessageCount)
                ) &&
                (
                    CharactersRemaining == input.CharactersRemaining ||
                    CharactersRemaining.Equals(input.CharactersRemaining)
                ) &&
                (
                    VarConfiguration == input.VarConfiguration ||
                    (VarConfiguration != null &&
                     VarConfiguration.Equals(input.VarConfiguration))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsPreview {\n");
            sb.Append("  TextPreview: ").Append(TextPreview).Append("\n");
            sb.Append("  MessageCount: ").Append(MessageCount).Append("\n");
            sb.Append("  CharactersRemaining: ").Append(CharactersRemaining).Append("\n");
            sb.Append("  VarConfiguration: ").Append(VarConfiguration).Append("\n");
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
            return Equals(input as SmsPreview);
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
                if (TextPreview != null)
                    hashCode = hashCode * 59 + TextPreview.GetHashCode();
                hashCode = hashCode * 59 + MessageCount.GetHashCode();
                hashCode = hashCode * 59 + CharactersRemaining.GetHashCode();
                if (VarConfiguration != null)
                    hashCode = hashCode * 59 + VarConfiguration.GetHashCode();
                return hashCode;
            }
        }
    }
}