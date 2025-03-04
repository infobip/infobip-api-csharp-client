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
    ///     TfaApplicationRequest
    /// </summary>
    [DataContract(Name = "TfaApplicationRequest")]
    [JsonObject]
    public class TfaApplicationRequest : IEquatable<TfaApplicationRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaApplicationRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TfaApplicationRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaApplicationRequest" /> class.
        /// </summary>
        /// <param name="varConfiguration">varConfiguration.</param>
        /// <param name="enabled">Indicates whether the created application is enabled..</param>
        /// <param name="name">2FA application name. (required).</param>
        public TfaApplicationRequest(TfaApplicationConfiguration varConfiguration = default, bool enabled = default,
            string name = default)
        {
            // to ensure "name" is required (not null)
            Name = name ?? throw new ArgumentNullException("name");
            VarConfiguration = varConfiguration;
            Enabled = enabled;
        }

        /// <summary>
        ///     Gets or Sets VarConfiguration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "configuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("configuration")]
        public TfaApplicationConfiguration VarConfiguration { get; set; }

        /// <summary>
        ///     Indicates whether the created application is enabled.
        /// </summary>
        /// <value>Indicates whether the created application is enabled.</value>
        [DataMember(Name = "enabled", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "enabled", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        ///     2FA application name.
        /// </summary>
        /// <value>2FA application name.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "name", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Returns true if TfaApplicationRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaApplicationRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaApplicationRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    VarConfiguration == input.VarConfiguration ||
                    (VarConfiguration != null &&
                     VarConfiguration.Equals(input.VarConfiguration))
                ) &&
                (
                    Enabled == input.Enabled ||
                    Enabled.Equals(input.Enabled)
                ) &&
                (
                    Name == input.Name ||
                    (Name != null &&
                     Name.Equals(input.Name))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TfaApplicationRequest {\n");
            sb.Append("  VarConfiguration: ").Append(VarConfiguration).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return Equals(input as TfaApplicationRequest);
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
                if (VarConfiguration != null)
                    hashCode = hashCode * 59 + VarConfiguration.GetHashCode();
                hashCode = hashCode * 59 + Enabled.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                return hashCode;
            }
        }
    }
}