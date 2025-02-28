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
    ///     NumberMaskingCredentialsBody
    /// </summary>
    [DataContract(Name = "NumberMaskingCredentialsBody")]
    [JsonObject]
    public class NumberMaskingCredentialsBody : IEquatable<NumberMaskingCredentialsBody>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingCredentialsBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NumberMaskingCredentialsBody()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingCredentialsBody" /> class.
        /// </summary>
        /// <param name="apiId">The first part of the generate Authorization header. (required).</param>
        /// <param name="key">Used to generate the second part of the Authorization header. (required).</param>
        public NumberMaskingCredentialsBody(string apiId = default, string key = default)
        {
            // to ensure "apiId" is required (not null)
            ApiId = apiId ?? throw new ArgumentNullException("apiId");
            // to ensure "key" is required (not null)
            Key = key ?? throw new ArgumentNullException("key");
        }

        /// <summary>
        ///     The first part of the generate Authorization header.
        /// </summary>
        /// <value>The first part of the generate Authorization header.</value>
        [DataMember(Name = "apiId", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "apiId", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("apiId")]
        public string ApiId { get; set; }

        /// <summary>
        ///     Used to generate the second part of the Authorization header.
        /// </summary>
        /// <value>Used to generate the second part of the Authorization header.</value>
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "key", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        ///     Returns true if NumberMaskingCredentialsBody instances are equal
        /// </summary>
        /// <param name="input">Instance of NumberMaskingCredentialsBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NumberMaskingCredentialsBody input)
        {
            if (input == null)
                return false;

            return
                (
                    ApiId == input.ApiId ||
                    (ApiId != null &&
                     ApiId.Equals(input.ApiId))
                ) &&
                (
                    Key == input.Key ||
                    (Key != null &&
                     Key.Equals(input.Key))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NumberMaskingCredentialsBody {\n");
            sb.Append("  ApiId: ").Append(ApiId).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
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
            return Equals(input as NumberMaskingCredentialsBody);
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
                if (ApiId != null)
                    hashCode = hashCode * 59 + ApiId.GetHashCode();
                if (Key != null)
                    hashCode = hashCode * 59 + Key.GetHashCode();
                return hashCode;
            }
        }
    }
}