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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     SmsResponse
    /// </summary>
    [DataContract(Name = "SmsResponse")]
    public class SmsResponse : IEquatable<SmsResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmsResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public SmsResponse()
        {
        }

        /// <summary>
        ///     The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than one
        ///     destination address.
        /// </summary>
        /// <value>
        ///     The ID that uniquely identifies the request. Bulk ID will be received only when you send a message to more than
        ///     one destination address.
        /// </value>
        [DataMember(Name = "bulkId", EmitDefaultValue = false)]
        public string BulkId { get; private set; }

        /// <summary>
        ///     Array of sent message objects, one object per every message.
        /// </summary>
        /// <value>Array of sent message objects, one object per every message.</value>
        [DataMember(Name = "messages", EmitDefaultValue = false)]
        public List<SmsResponseDetails> Messages { get; private set; }

        /// <summary>
        ///     Returns false as BulkId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeBulkId()
        {
            return false;
        }

        /// <summary>
        ///     Returns false as Messages should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeMessages()
        {
            return false;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SmsResponse {\n");
            sb.Append("  BulkId: ").Append(BulkId).Append("\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
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
            return Equals(input as SmsResponse);
        }

        /// <summary>
        ///     Returns true if SmsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of SmsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SmsResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    BulkId == input.BulkId ||
                    BulkId != null &&
                    BulkId.Equals(input.BulkId)
                ) &&
                (
                    Messages == input.Messages ||
                    Messages != null &&
                    input.Messages != null &&
                    Messages.SequenceEqual(input.Messages)
                );
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (BulkId != null)
                    hashCode = hashCode * 59 + BulkId.GetHashCode();
                if (Messages != null)
                    hashCode = hashCode * 59 + Messages.GetHashCode();
                return hashCode;
            }
        }
    }
}