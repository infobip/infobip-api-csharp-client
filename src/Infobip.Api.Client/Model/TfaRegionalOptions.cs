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
    ///     Region-specific parameters, often imposed by local laws. Use this, if country or region that you are sending a
    ///     message to requires additional information.
    /// </summary>
    [DataContract(Name = "TfaRegionalOptions")]
    [JsonObject]
    public class TfaRegionalOptions : IEquatable<TfaRegionalOptions>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaRegionalOptions" /> class.
        /// </summary>
        /// <param name="indiaDlt">indiaDlt.</param>
        public TfaRegionalOptions(TfaIndiaDltOptions indiaDlt = default)
        {
            IndiaDlt = indiaDlt;
        }

        /// <summary>
        ///     Gets or Sets IndiaDlt
        /// </summary>
        [DataMember(Name = "indiaDlt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "indiaDlt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("indiaDlt")]
        public TfaIndiaDltOptions IndiaDlt { get; set; }

        /// <summary>
        ///     Returns true if TfaRegionalOptions instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaRegionalOptions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaRegionalOptions input)
        {
            if (input == null)
                return false;

            return
                IndiaDlt == input.IndiaDlt ||
                (IndiaDlt != null &&
                 IndiaDlt.Equals(input.IndiaDlt));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaRegionalOptions {\n");
            sb.Append("  IndiaDlt: ").Append(IndiaDlt).Append("\n");
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
            return Equals(input as TfaRegionalOptions);
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
                if (IndiaDlt != null)
                    hashCode = hashCode * 59 + IndiaDlt.GetHashCode();
                return hashCode;
            }
        }
    }
}