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
    ///     CallsConferenceAndCall
    /// </summary>
    [DataContract(Name = "CallsConferenceAndCall")]
    [JsonObject]
    public class CallsConferenceAndCall : IEquatable<CallsConferenceAndCall>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsConferenceAndCall" /> class.
        /// </summary>
        /// <param name="conference">conference.</param>
        /// <param name="call">call.</param>
        public CallsConferenceAndCall(CallsConference conference = default, Call call = default)
        {
            Conference = conference;
            Call = call;
        }

        /// <summary>
        ///     Gets or Sets Conference
        /// </summary>
        [DataMember(Name = "conference", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "conference", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("conference")]
        public CallsConference Conference { get; set; }

        /// <summary>
        ///     Gets or Sets Call
        /// </summary>
        [DataMember(Name = "call", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "call", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("call")]
        public Call Call { get; set; }

        /// <summary>
        ///     Returns true if CallsConferenceAndCall instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsConferenceAndCall to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsConferenceAndCall input)
        {
            if (input == null)
                return false;

            return
                (
                    Conference == input.Conference ||
                    (Conference != null &&
                     Conference.Equals(input.Conference))
                ) &&
                (
                    Call == input.Call ||
                    (Call != null &&
                     Call.Equals(input.Call))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsConferenceAndCall {\n");
            sb.Append("  Conference: ").Append(Conference).Append("\n");
            sb.Append("  Call: ").Append(Call).Append("\n");
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
            return Equals(input as CallsConferenceAndCall);
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
                if (Conference != null)
                    hashCode = hashCode * 59 + Conference.GetHashCode();
                if (Call != null)
                    hashCode = hashCode * 59 + Call.GetHashCode();
                return hashCode;
            }
        }
    }
}