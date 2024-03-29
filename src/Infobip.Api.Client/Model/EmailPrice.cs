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
    ///     Sent email price.
    /// </summary>
    [DataContract(Name = "EmailPrice")]
    public class EmailPrice : IEquatable<EmailPrice>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailPrice" /> class.
        /// </summary>
        /// <param name="pricePerMessage">Price per one email request..</param>
        /// <param name="currency">The currency in which the price is expressed..</param>
        public EmailPrice(decimal pricePerMessage = default(decimal), string currency = default(string))
        {
            PricePerMessage = pricePerMessage;
            Currency = currency;
        }

        /// <summary>
        ///     Price per one email request.
        /// </summary>
        /// <value>Price per one email request.</value>
        [DataMember(Name = "pricePerMessage", EmitDefaultValue = false)]
        public decimal PricePerMessage { get; set; }

        /// <summary>
        ///     The currency in which the price is expressed.
        /// </summary>
        /// <value>The currency in which the price is expressed.</value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailPrice {\n");
            sb.Append("  PricePerMessage: ").Append(PricePerMessage).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
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
            return Equals(input as EmailPrice);
        }

        /// <summary>
        ///     Returns true if EmailPrice instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailPrice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailPrice input)
        {
            if (input == null)
                return false;

            return
                (
                    PricePerMessage == input.PricePerMessage ||
                    PricePerMessage.Equals(input.PricePerMessage)
                ) &&
                (
                    Currency == input.Currency ||
                    Currency != null &&
                    Currency.Equals(input.Currency)
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
                hashCode = hashCode * 59 + PricePerMessage.GetHashCode();
                if (Currency != null)
                    hashCode = hashCode * 59 + Currency.GetHashCode();
                return hashCode;
            }
        }
    }
}