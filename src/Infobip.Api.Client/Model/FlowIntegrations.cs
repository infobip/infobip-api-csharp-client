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
    ///     Integrations.
    /// </summary>
    [DataContract(Name = "FlowIntegrations")]
    [JsonObject]
    public class FlowIntegrations : IEquatable<FlowIntegrations>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FlowIntegrations" /> class.
        /// </summary>
        /// <param name="salesforce">salesforce.</param>
        public FlowIntegrations(FlowSalesforce salesforce = default)
        {
            Salesforce = salesforce;
        }

        /// <summary>
        ///     Gets or Sets Salesforce
        /// </summary>
        [DataMember(Name = "salesforce", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "salesforce", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("salesforce")]
        public FlowSalesforce Salesforce { get; set; }

        /// <summary>
        ///     Returns true if FlowIntegrations instances are equal
        /// </summary>
        /// <param name="input">Instance of FlowIntegrations to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FlowIntegrations input)
        {
            if (input == null)
                return false;

            return
                Salesforce == input.Salesforce ||
                (Salesforce != null &&
                 Salesforce.Equals(input.Salesforce));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FlowIntegrations {\n");
            sb.Append("  Salesforce: ").Append(Salesforce).Append("\n");
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
            return Equals(input as FlowIntegrations);
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
                if (Salesforce != null)
                    hashCode = hashCode * 59 + Salesforce.GetHashCode();
                return hashCode;
            }
        }
    }
}