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
    ///     NumberMaskingSetupBody
    /// </summary>
    [DataContract(Name = "NumberMaskingSetupBody")]
    [JsonObject]
    public class NumberMaskingSetupBody : IEquatable<NumberMaskingSetupBody>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingSetupBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NumberMaskingSetupBody()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberMaskingSetupBody" /> class.
        /// </summary>
        /// <param name="name">Unique configuration name. Alphanumeric, max length 100. (required).</param>
        /// <param name="callbackUrl">
        ///     Client&#39;s URL that will be called on each inbound call to related Number masking Voice
        ///     number in order to get instructions of how to handle incoming calls. Instructions are a result of mapping logic
        ///     implemented on your side according to your business case. (required).
        /// </param>
        /// <param name="statusUrl">Client&#39;s URL for status report delivery after the call is finished..</param>
        /// <param name="backupCallbackUrl">If callbackUrl is unavailable this one will be called instead..</param>
        /// <param name="backupStatusUrl">If statusUrl is unavailable this one will be called instead..</param>
        /// <param name="description">Masking configuration description..</param>
        public NumberMaskingSetupBody(string name = default, string callbackUrl = default, string statusUrl = default,
            string backupCallbackUrl = default, string backupStatusUrl = default, string description = default)
        {
            // to ensure "name" is required (not null)
            Name = name ?? throw new ArgumentNullException("name");
            // to ensure "callbackUrl" is required (not null)
            CallbackUrl = callbackUrl ?? throw new ArgumentNullException("callbackUrl");
            StatusUrl = statusUrl;
            BackupCallbackUrl = backupCallbackUrl;
            BackupStatusUrl = backupStatusUrl;
            Description = description;
        }

        /// <summary>
        ///     Unique configuration name. Alphanumeric, max length 100.
        /// </summary>
        /// <value>Unique configuration name. Alphanumeric, max length 100.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "name", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Client&#39;s URL that will be called on each inbound call to related Number masking Voice number in order to get
        ///     instructions of how to handle incoming calls. Instructions are a result of mapping logic implemented on your side
        ///     according to your business case.
        /// </summary>
        /// <value>
        ///     Client&#39;s URL that will be called on each inbound call to related Number masking Voice number in order to get
        ///     instructions of how to handle incoming calls. Instructions are a result of mapping logic implemented on your side
        ///     according to your business case.
        /// </value>
        [DataMember(Name = "callbackUrl", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "callbackUrl", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("callbackUrl")]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///     Client&#39;s URL for status report delivery after the call is finished.
        /// </summary>
        /// <value>Client&#39;s URL for status report delivery after the call is finished.</value>
        [DataMember(Name = "statusUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "statusUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("statusUrl")]
        public string StatusUrl { get; set; }

        /// <summary>
        ///     If callbackUrl is unavailable this one will be called instead.
        /// </summary>
        /// <value>If callbackUrl is unavailable this one will be called instead.</value>
        [DataMember(Name = "backupCallbackUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "backupCallbackUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("backupCallbackUrl")]
        public string BackupCallbackUrl { get; set; }

        /// <summary>
        ///     If statusUrl is unavailable this one will be called instead.
        /// </summary>
        /// <value>If statusUrl is unavailable this one will be called instead.</value>
        [DataMember(Name = "backupStatusUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "backupStatusUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("backupStatusUrl")]
        public string BackupStatusUrl { get; set; }

        /// <summary>
        ///     Masking configuration description.
        /// </summary>
        /// <value>Masking configuration description.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Returns true if NumberMaskingSetupBody instances are equal
        /// </summary>
        /// <param name="input">Instance of NumberMaskingSetupBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NumberMaskingSetupBody input)
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
                    CallbackUrl == input.CallbackUrl ||
                    (CallbackUrl != null &&
                     CallbackUrl.Equals(input.CallbackUrl))
                ) &&
                (
                    StatusUrl == input.StatusUrl ||
                    (StatusUrl != null &&
                     StatusUrl.Equals(input.StatusUrl))
                ) &&
                (
                    BackupCallbackUrl == input.BackupCallbackUrl ||
                    (BackupCallbackUrl != null &&
                     BackupCallbackUrl.Equals(input.BackupCallbackUrl))
                ) &&
                (
                    BackupStatusUrl == input.BackupStatusUrl ||
                    (BackupStatusUrl != null &&
                     BackupStatusUrl.Equals(input.BackupStatusUrl))
                ) &&
                (
                    Description == input.Description ||
                    (Description != null &&
                     Description.Equals(input.Description))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NumberMaskingSetupBody {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CallbackUrl: ").Append(CallbackUrl).Append("\n");
            sb.Append("  StatusUrl: ").Append(StatusUrl).Append("\n");
            sb.Append("  BackupCallbackUrl: ").Append(BackupCallbackUrl).Append("\n");
            sb.Append("  BackupStatusUrl: ").Append(BackupStatusUrl).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return Equals(input as NumberMaskingSetupBody);
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
                if (CallbackUrl != null)
                    hashCode = hashCode * 59 + CallbackUrl.GetHashCode();
                if (StatusUrl != null)
                    hashCode = hashCode * 59 + StatusUrl.GetHashCode();
                if (BackupCallbackUrl != null)
                    hashCode = hashCode * 59 + BackupCallbackUrl.GetHashCode();
                if (BackupStatusUrl != null)
                    hashCode = hashCode * 59 + BackupStatusUrl.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                return hashCode;
            }
        }
    }
}