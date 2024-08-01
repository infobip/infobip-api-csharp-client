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
using Newtonsoft.Json;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     Indicates the [status](https://www.infobip.com/docs/essentials/response-status-and-error-codes#api-status-codes) of
    ///     the message and how to recover from an error should there be any.
    /// </summary>
    [DataContract(Name = "TfaEmailStatus")]
    public class TfaEmailStatus : IEquatable<TfaEmailStatus>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TfaEmailStatus" /> class.
        /// </summary>
        /// <param name="description">Human-readable description of the status..</param>
        /// <param name="name">[Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes)..</param>
        public TfaEmailStatus(string description = default, string name = default)
        {
            Description = description;
            Name = name;
        }

        /// <summary>
        ///     Human-readable description of the status.
        /// </summary>
        /// <value>Human-readable description of the status.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        ///     [Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes).
        /// </summary>
        /// <value>[Status name](https://www.infobip.com/docs/essentials/response-status-and-error-codes).</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///     Returns true if TfaEmailStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of TfaEmailStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TfaEmailStatus input)
        {
            if (input == null)
                return false;

            return
                (
                    Description == input.Description ||
                    (Description != null &&
                     Description.Equals(input.Description))
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
            sb.Append("class TfaEmailStatus {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return Equals(input as TfaEmailStatus);
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
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                return hashCode;
            }
        }
    }
}