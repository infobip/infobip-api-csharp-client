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
    ///     SIP trunk service address country.
    /// </summary>
    [DataContract(Name = "CallsPublicCountry")]
    [JsonObject]
    public class CallsPublicCountry : IEquatable<CallsPublicCountry>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsPublicCountry" /> class.
        /// </summary>
        /// <param name="name">Name of the country where SIP trunk is located..</param>
        /// <param name="code">Code of the country where SIP trunk is located..</param>
        public CallsPublicCountry(string name = default, string code = default)
        {
            Name = name;
            Code = code;
        }

        /// <summary>
        ///     Name of the country where SIP trunk is located.
        /// </summary>
        /// <value>Name of the country where SIP trunk is located.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Code of the country where SIP trunk is located.
        /// </summary>
        /// <value>Code of the country where SIP trunk is located.</value>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Returns true if CallsPublicCountry instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsPublicCountry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsPublicCountry input)
        {
            if (input == null)
                return false;

            return
                (
                    Name == input.Name ||
                    (Name != null &&
                     Name.Equals(input.Name))
                ) &&
                (
                    Code == input.Code ||
                    (Code != null &&
                     Code.Equals(input.Code))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsPublicCountry {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
            return Equals(input as CallsPublicCountry);
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Code != null)
                    hashCode = hashCode * 59 + Code.GetHashCode();
                return hashCode;
            }
        }
    }
}