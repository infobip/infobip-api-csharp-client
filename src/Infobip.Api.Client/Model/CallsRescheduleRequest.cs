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
    ///     CallsRescheduleRequest
    /// </summary>
    [DataContract(Name = "CallsRescheduleRequest")]
    [JsonObject]
    public class CallsRescheduleRequest : IEquatable<CallsRescheduleRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsRescheduleRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsRescheduleRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsRescheduleRequest" /> class.
        /// </summary>
        /// <param name="startTime">Rescheduled start time. (required).</param>
        public CallsRescheduleRequest(DateTimeOffset startTime = default)
        {
            StartTime = startTime;
        }

        /// <summary>
        ///     Rescheduled start time.
        /// </summary>
        /// <value>Rescheduled start time.</value>
        [DataMember(Name = "startTime", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "startTime", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("startTime")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        ///     Returns true if CallsRescheduleRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsRescheduleRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsRescheduleRequest input)
        {
            if (input == null)
                return false;

            return
                StartTime == input.StartTime ||
                (StartTime != null &&
                 StartTime.Equals(input.StartTime));
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsRescheduleRequest {\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
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
            return Equals(input as CallsRescheduleRequest);
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
                if (StartTime != null)
                    hashCode = hashCode * 59 + StartTime.GetHashCode();
                return hashCode;
            }
        }
    }
}