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
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     FormsResponseContent
    /// </summary>
    [DataContract(Name = "FormsResponseContent")]
    [JsonObject]
    public class FormsResponseContent : IEquatable<FormsResponseContent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FormsResponseContent" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FormsResponseContent()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FormsResponseContent" /> class.
        /// </summary>
        /// <param name="id">Form identifier (required).</param>
        /// <param name="name">Form name (required).</param>
        /// <param name="elements">List of form fields (required).</param>
        /// <param name="createdAt">Time when form was created.</param>
        /// <param name="updatedAt">Time when form was update last time.</param>
        /// <param name="actionAfterSubmission">actionAfterSubmission.</param>
        /// <param name="resubmitEnabled">Can resubmit multiple times (required).</param>
        /// <param name="formType">formType (required).</param>
        /// <param name="formStatus">formStatus (required).</param>
        public FormsResponseContent(string id = default, string name = default, List<FormsElement> elements = default,
            DateTimeOffset createdAt = default, DateTimeOffset updatedAt = default,
            FormsActionAfterSubmission actionAfterSubmission = default, bool resubmitEnabled = default,
            FormsType formType = default, FormsStatus formStatus = default)
        {
            // to ensure "id" is required (not null)
            Id = id ?? throw new ArgumentNullException("id");
            // to ensure "name" is required (not null)
            Name = name ?? throw new ArgumentNullException("name");
            // to ensure "elements" is required (not null)
            Elements = elements ?? throw new ArgumentNullException("elements");
            ResubmitEnabled = resubmitEnabled;
            FormType = formType;
            FormStatus = formStatus;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ActionAfterSubmission = actionAfterSubmission;
        }

        /// <summary>
        ///     Gets or Sets FormType
        /// </summary>
        [DataMember(Name = "formType", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "formType", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("formType")]
        public FormsType FormType { get; set; }

        /// <summary>
        ///     Gets or Sets FormStatus
        /// </summary>
        [DataMember(Name = "formStatus", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "formStatus", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("formStatus")]
        public FormsStatus FormStatus { get; set; }

        /// <summary>
        ///     Form identifier
        /// </summary>
        /// <value>Form identifier</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "id", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Form name
        /// </summary>
        /// <value>Form name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "name", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     List of form fields
        /// </summary>
        /// <value>List of form fields</value>
        [DataMember(Name = "elements", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "elements", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("elements")]
        public List<FormsElement> Elements { get; set; }

        /// <summary>
        ///     Time when form was created
        /// </summary>
        /// <value>Time when form was created</value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "createdAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("createdAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        ///     Time when form was update last time
        /// </summary>
        /// <value>Time when form was update last time</value>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "updatedAt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("updatedAt")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        ///     Gets or Sets ActionAfterSubmission
        /// </summary>
        [DataMember(Name = "actionAfterSubmission", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "actionAfterSubmission", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("actionAfterSubmission")]
        public FormsActionAfterSubmission ActionAfterSubmission { get; set; }

        /// <summary>
        ///     Can resubmit multiple times
        /// </summary>
        /// <value>Can resubmit multiple times</value>
        [DataMember(Name = "resubmitEnabled", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "resubmitEnabled", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("resubmitEnabled")]
        public bool ResubmitEnabled { get; set; }

        /// <summary>
        ///     Returns true if FormsResponseContent instances are equal
        /// </summary>
        /// <param name="input">Instance of FormsResponseContent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FormsResponseContent input)
        {
            if (input == null)
                return false;

            return
                (
                    Id == input.Id ||
                    (Id != null &&
                     Id.Equals(input.Id))
                ) &&
                (
                    Name == input.Name ||
                    (Name != null &&
                     Name.Equals(input.Name))
                ) &&
                (
                    Elements == input.Elements ||
                    (Elements != null &&
                     input.Elements != null &&
                     Elements.SequenceEqual(input.Elements))
                ) &&
                (
                    CreatedAt == input.CreatedAt ||
                    (CreatedAt != null &&
                     CreatedAt.Equals(input.CreatedAt))
                ) &&
                (
                    UpdatedAt == input.UpdatedAt ||
                    (UpdatedAt != null &&
                     UpdatedAt.Equals(input.UpdatedAt))
                ) &&
                (
                    ActionAfterSubmission == input.ActionAfterSubmission ||
                    (ActionAfterSubmission != null &&
                     ActionAfterSubmission.Equals(input.ActionAfterSubmission))
                ) &&
                (
                    ResubmitEnabled == input.ResubmitEnabled ||
                    ResubmitEnabled.Equals(input.ResubmitEnabled)
                ) &&
                (
                    FormType == input.FormType ||
                    FormType.Equals(input.FormType)
                ) &&
                (
                    FormStatus == input.FormStatus ||
                    FormStatus.Equals(input.FormStatus)
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FormsResponseContent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Elements: ").Append(Elements).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  ActionAfterSubmission: ").Append(ActionAfterSubmission).Append("\n");
            sb.Append("  ResubmitEnabled: ").Append(ResubmitEnabled).Append("\n");
            sb.Append("  FormType: ").Append(FormType).Append("\n");
            sb.Append("  FormStatus: ").Append(FormStatus).Append("\n");
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
            return Equals(input as FormsResponseContent);
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Elements != null)
                    hashCode = hashCode * 59 + Elements.GetHashCode();
                if (CreatedAt != null)
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                if (UpdatedAt != null)
                    hashCode = hashCode * 59 + UpdatedAt.GetHashCode();
                if (ActionAfterSubmission != null)
                    hashCode = hashCode * 59 + ActionAfterSubmission.GetHashCode();
                hashCode = hashCode * 59 + ResubmitEnabled.GetHashCode();
                hashCode = hashCode * 59 + FormType.GetHashCode();
                hashCode = hashCode * 59 + FormStatus.GetHashCode();
                return hashCode;
            }
        }
    }
}