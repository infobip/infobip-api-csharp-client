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
    ///     Use case dependent parameters for sending SMS to phone numbers registered in South Korea.
    /// </summary>
    [DataContract(Name = "SmsSouthKoreaOptions")]
    [JsonObject]
    public class SmsSouthKoreaOptions : IEquatable<SmsSouthKoreaOptions>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsSouthKoreaOptions" /> class.
        /// </summary>
        /// <param name="title">Title of the message..</param>
        /// <param name="resellerCode">
        ///     Reseller identification code: 9-digit registration number in the business registration
        ///     certificate for South Korea. Resellers should submit this when sending..
        /// </param>
        public SmsSouthKoreaOptions(string title = default, int resellerCode = default)
        {
            Title = title;
            ResellerCode = resellerCode;
        }

        /// <summary>
        ///     Title of the message.
        /// </summary>
        /// <value>Title of the message.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Reseller identification code: 9-digit registration number in the business registration certificate for South Korea.
        ///     Resellers should submit this when sending.
        /// </summary>
        /// <value>
        ///     Reseller identification code: 9-digit registration number in the business registration certificate for South
        ///     Korea. Resellers should submit this when sending.
        /// </value>
        [DataMember(Name = "resellerCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resellerCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("resellerCode")]
        public int ResellerCode { get; set; }

        /// <summary>
        ///     Returns true if SmsSouthKoreaOptions instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsSouthKoreaOptions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsSouthKoreaOptions input)
        {
            if (input == null)
                return false;

            return
                (
                    Title == input.Title ||
                    (Title != null &&
                     Title.Equals(input.Title))
                ) &&
                (
                    ResellerCode == input.ResellerCode ||
                    ResellerCode.Equals(input.ResellerCode)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsSouthKoreaOptions {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  ResellerCode: ").Append(ResellerCode).Append("\n");
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
            return Equals(input as SmsSouthKoreaOptions);
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
                if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                hashCode = hashCode * 59 + ResellerCode.GetHashCode();
                return hashCode;
            }
        }
    }
}