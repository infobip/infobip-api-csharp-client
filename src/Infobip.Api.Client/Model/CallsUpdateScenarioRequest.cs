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
using Newtonsoft.Json.Linq;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallsUpdateScenarioRequest
    /// </summary>
    [DataContract(Name = "CallsUpdateScenarioRequest")]
    [JsonObject]
    public class CallsUpdateScenarioRequest : IEquatable<CallsUpdateScenarioRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsUpdateScenarioRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsUpdateScenarioRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsUpdateScenarioRequest" /> class.
        /// </summary>
        /// <param name="name">The name of IVR scenario. (required).</param>
        /// <param name="description">Description of IVR scenario..</param>
        /// <param name="script">script (required).</param>
        public CallsUpdateScenarioRequest(string name = default, string description = default, JRaw script = default)
        {
            // to ensure "name" is required (not null)
            Name = name ?? throw new ArgumentNullException("name");
            // to ensure "script" is required (not null)
            Script = script ?? throw new ArgumentNullException("script");
            Description = description;
        }

        /// <summary>
        ///     The name of IVR scenario.
        /// </summary>
        /// <value>The name of IVR scenario.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "name", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Description of IVR scenario.
        /// </summary>
        /// <value>Description of IVR scenario.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or Sets Script
        /// </summary>
        [DataMember(Name = "script", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "script", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("script")]
        public JRaw Script { get; set; }

        /// <summary>
        ///     Returns true if CallsUpdateScenarioRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsUpdateScenarioRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsUpdateScenarioRequest input)
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
                    Description == input.Description ||
                    (Description != null &&
                     Description.Equals(input.Description))
                ) &&
                (
                    Script == input.Script ||
                    (Script != null &&
                     Script.Equals(input.Script))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsUpdateScenarioRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Script: ").Append(Script).Append("\n");
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
            return Equals(input as CallsUpdateScenarioRequest);
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
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Script != null)
                    hashCode = hashCode * 59 + Script.GetHashCode();
                return hashCode;
            }
        }
    }
}