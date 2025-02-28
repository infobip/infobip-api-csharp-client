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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Infobip SBC (Session Border Controller) hosts.
    /// </summary>
    [DataContract(Name = "CallsSbcHosts")]
    [JsonObject]
    public class CallsSbcHosts : IEquatable<CallsSbcHosts>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsSbcHosts" /> class.
        /// </summary>
        /// <param name="primary">primary.</param>
        /// <param name="backup">backup.</param>
        public CallsSbcHosts(List<string> primary = default, List<string> backup = default)
        {
            Primary = primary;
            Backup = backup;
        }

        /// <summary>
        ///     Gets or Sets Primary
        /// </summary>
        [DataMember(Name = "primary", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "primary", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("primary")]
        public List<string> Primary { get; set; }

        /// <summary>
        ///     Gets or Sets Backup
        /// </summary>
        [DataMember(Name = "backup", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "backup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("backup")]
        public List<string> Backup { get; set; }

        /// <summary>
        ///     Returns true if CallsSbcHosts instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsSbcHosts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsSbcHosts input)
        {
            if (input == null)
                return false;

            return
                (
                    Primary == input.Primary ||
                    (Primary != null &&
                     input.Primary != null &&
                     Primary.SequenceEqual(input.Primary))
                ) &&
                (
                    Backup == input.Backup ||
                    (Backup != null &&
                     input.Backup != null &&
                     Backup.SequenceEqual(input.Backup))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsSbcHosts {\n");
            sb.Append("  Primary: ").Append(Primary).Append("\n");
            sb.Append("  Backup: ").Append(Backup).Append("\n");
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
            return Equals(input as CallsSbcHosts);
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
                if (Primary != null)
                    hashCode = hashCode * 59 + Primary.GetHashCode();
                if (Backup != null)
                    hashCode = hashCode * 59 + Backup.GetHashCode();
                return hashCode;
            }
        }
    }
}