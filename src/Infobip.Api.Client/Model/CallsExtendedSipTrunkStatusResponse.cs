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
    ///     CallsExtendedSipTrunkStatusResponse
    /// </summary>
    [DataContract(Name = "CallsExtendedSipTrunkStatusResponse")]
    [JsonObject]
    public class CallsExtendedSipTrunkStatusResponse : IEquatable<CallsExtendedSipTrunkStatusResponse>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsExtendedSipTrunkStatusResponse" /> class.
        /// </summary>
        /// <param name="adminStatus">adminStatus.</param>
        /// <param name="actionStatus">actionStatus.</param>
        /// <param name="registrationStatus">registrationStatus.</param>
        /// <param name="activeCalls">Number of active calls..</param>
        public CallsExtendedSipTrunkStatusResponse(CallsSipTrunkAdminStatus? adminStatus = default,
            CallsSipTrunkActionStatusResponse actionStatus = default,
            CallsSipTrunkRegistrationStatus? registrationStatus = default, int activeCalls = default)
        {
            AdminStatus = adminStatus;
            ActionStatus = actionStatus;
            RegistrationStatus = registrationStatus;
            ActiveCalls = activeCalls;
        }

        /// <summary>
        ///     Gets or Sets AdminStatus
        /// </summary>
        [DataMember(Name = "adminStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "adminStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("adminStatus")]
        public CallsSipTrunkAdminStatus? AdminStatus { get; set; }

        /// <summary>
        ///     Gets or Sets RegistrationStatus
        /// </summary>
        [DataMember(Name = "registrationStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "registrationStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("registrationStatus")]
        public CallsSipTrunkRegistrationStatus? RegistrationStatus { get; set; }

        /// <summary>
        ///     Gets or Sets ActionStatus
        /// </summary>
        [DataMember(Name = "actionStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "actionStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("actionStatus")]
        public CallsSipTrunkActionStatusResponse ActionStatus { get; set; }

        /// <summary>
        ///     Number of active calls.
        /// </summary>
        /// <value>Number of active calls.</value>
        [DataMember(Name = "activeCalls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "activeCalls", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("activeCalls")]
        public int ActiveCalls { get; set; }

        /// <summary>
        ///     Returns true if CallsExtendedSipTrunkStatusResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsExtendedSipTrunkStatusResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsExtendedSipTrunkStatusResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    AdminStatus == input.AdminStatus ||
                    AdminStatus.Equals(input.AdminStatus)
                ) &&
                (
                    ActionStatus == input.ActionStatus ||
                    (ActionStatus != null &&
                     ActionStatus.Equals(input.ActionStatus))
                ) &&
                (
                    RegistrationStatus == input.RegistrationStatus ||
                    RegistrationStatus.Equals(input.RegistrationStatus)
                ) &&
                (
                    ActiveCalls == input.ActiveCalls ||
                    ActiveCalls.Equals(input.ActiveCalls)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsExtendedSipTrunkStatusResponse {\n");
            sb.Append("  AdminStatus: ").Append(AdminStatus).Append("\n");
            sb.Append("  ActionStatus: ").Append(ActionStatus).Append("\n");
            sb.Append("  RegistrationStatus: ").Append(RegistrationStatus).Append("\n");
            sb.Append("  ActiveCalls: ").Append(ActiveCalls).Append("\n");
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
            return Equals(input as CallsExtendedSipTrunkStatusResponse);
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
                hashCode = hashCode * 59 + AdminStatus.GetHashCode();
                if (ActionStatus != null)
                    hashCode = hashCode * 59 + ActionStatus.GetHashCode();
                hashCode = hashCode * 59 + RegistrationStatus.GetHashCode();
                hashCode = hashCode * 59 + ActiveCalls.GetHashCode();
                return hashCode;
            }
        }
    }
}