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
    ///     SmsTextContent
    /// </summary>
    [DataContract(Name = "SmsTextContent")]
    [JsonObject]
    public class SmsTextContent : IEquatable<SmsTextContent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsTextContent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SmsTextContent()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsTextContent" /> class.
        /// </summary>
        /// <param name="text">Content of the message being sent. (required).</param>
        /// <param name="transliteration">transliteration.</param>
        /// <param name="language">language.</param>
        public SmsTextContent(string text = default, SmsTransliterationCode? transliteration = default,
            SmsLanguage language = default)
        {
            // to ensure "text" is required (not null)
            Text = text ?? throw new ArgumentNullException("text");
            Transliteration = transliteration;
            Language = language;
        }

        /// <summary>
        ///     Gets or Sets Transliteration
        /// </summary>
        [DataMember(Name = "transliteration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "transliteration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("transliteration")]
        public SmsTransliterationCode? Transliteration { get; set; }

        /// <summary>
        ///     Content of the message being sent.
        /// </summary>
        /// <value>Content of the message being sent.</value>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "text", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Gets or Sets Language
        /// </summary>
        [DataMember(Name = "language", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "language", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("language")]
        public SmsLanguage Language { get; set; }

        /// <summary>
        ///     Returns true if SmsTextContent instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsTextContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsTextContent input)
        {
            if (input == null)
                return false;

            return
                (
                    Text == input.Text ||
                    (Text != null &&
                     Text.Equals(input.Text))
                ) &&
                (
                    Transliteration == input.Transliteration ||
                    Transliteration.Equals(input.Transliteration)
                ) &&
                (
                    Language == input.Language ||
                    (Language != null &&
                     Language.Equals(input.Language))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsTextContent {\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Transliteration: ").Append(Transliteration).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
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
            return Equals(input as SmsTextContent);
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
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                hashCode = hashCode * 59 + Transliteration.GetHashCode();
                if (Language != null)
                    hashCode = hashCode * 59 + Language.GetHashCode();
                return hashCode;
            }
        }
    }
}