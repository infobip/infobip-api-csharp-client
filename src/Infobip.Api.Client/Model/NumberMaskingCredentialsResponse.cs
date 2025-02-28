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
    ///     NumberMaskingCredentialsResponse
    /// </summary>
    [DataContract(Name = "NumberMaskingCredentialsResponse")]
    [JsonObject]
    public class NumberMaskingCredentialsResponse : IEquatable<NumberMaskingCredentialsResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingCredentialsResponse" /> class.
        /// </summary>
        /// <param name="apiId">The first part of the generate Authorization header..</param>
        /// <param name="key">Used to generate the second part of the Authorization header..</param>
        public NumberMaskingCredentialsResponse(string apiId = default, string key = default)
        {
            ApiId = apiId;
            Key = key;
        }

        /// <summary>
        ///     The first part of the generate Authorization header.
        /// </summary>
        /// <value>The first part of the generate Authorization header.</value>
        [DataMember(Name = "apiId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "apiId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("apiId")]
        public string ApiId { get; set; }

        /// <summary>
        ///     Used to generate the second part of the Authorization header.
        /// </summary>
        /// <value>Used to generate the second part of the Authorization header.</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "key", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        ///     Returns true if NumberMaskingCredentialsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of NumberMaskingCredentialsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NumberMaskingCredentialsResponse input)
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
            sb.Append("class NumberMaskingCredentialsResponse {\n");
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
            return Equals(input as NumberMaskingCredentialsResponse);
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