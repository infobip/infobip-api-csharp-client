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
    ///     If set, captures the call session from an established call to a given destination.
    /// </summary>
    [DataContract(Name = "CallRoutingRecording")]
    [JsonObject]
    public class CallRoutingRecording : IEquatable<CallRoutingRecording>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingRecording" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallRoutingRecording()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallRoutingRecording" /> class.
        /// </summary>
        /// <param name="recordingType">recordingType (required).</param>
        /// <param name="recordingComposition">recordingComposition.</param>
        /// <param name="customData">Client-defined data visible when a recording is downloaded..</param>
        /// <param name="filePrefix">
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on
        ///     [Voice settings page](https://portal.infobip.com/apps/voice/recording/settings). For recordings without
        ///     composition, &#x60;callId&#x60; and &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value. For
        ///     recordings with composition, &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value..
        /// </param>
        public CallRoutingRecording(CallRoutingRecordingType recordingType = default,
            CallRoutingRecordingComposition recordingComposition = default,
            Dictionary<string, string> customData = default, string filePrefix = default)
        {
            RecordingType = recordingType;
            RecordingComposition = recordingComposition;
            CustomData = customData;
            FilePrefix = filePrefix;
        }

        /// <summary>
        ///     Gets or Sets RecordingType
        /// </summary>
        [DataMember(Name = "recordingType", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "recordingType", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("recordingType")]
        public CallRoutingRecordingType RecordingType { get; set; }

        /// <summary>
        ///     Gets or Sets RecordingComposition
        /// </summary>
        [DataMember(Name = "recordingComposition", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "recordingComposition", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("recordingComposition")]
        public CallRoutingRecordingComposition RecordingComposition { get; set; }

        /// <summary>
        ///     Client-defined data visible when a recording is downloaded.
        /// </summary>
        /// <value>Client-defined data visible when a recording is downloaded.</value>
        [DataMember(Name = "customData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("customData")]
        public Dictionary<string, string> CustomData { get; set; }

        /// <summary>
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on [Voice settings
        ///     page](https://portal.infobip.com/apps/voice/recording/settings). For recordings without composition, &#x60;callId
        ///     &#x60; and &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value. For recordings with
        ///     composition, &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value.
        /// </summary>
        /// <value>
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on [Voice settings
        ///     page](https://portal.infobip.com/apps/voice/recording/settings). For recordings without composition, &#x60;callId
        ///     &#x60; and &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value. For recordings with
        ///     composition, &#x60;fileId&#x60; will be appended to the &#x60;filePrefix&#x60; value.
        /// </value>
        [DataMember(Name = "filePrefix", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filePrefix", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("filePrefix")]
        public string FilePrefix { get; set; }

        /// <summary>
        ///     Returns true if CallRoutingRecording instances are equal
        /// </summary>
        /// <param name="input">Instance of CallRoutingRecording to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallRoutingRecording input)
        {
            if (input == null)
                return false;

            return
                (
                    RecordingType == input.RecordingType ||
                    RecordingType.Equals(input.RecordingType)
                ) &&
                (
                    RecordingComposition == input.RecordingComposition ||
                    (RecordingComposition != null &&
                     RecordingComposition.Equals(input.RecordingComposition))
                ) &&
                (
                    CustomData == input.CustomData ||
                    (CustomData != null &&
                     input.CustomData != null &&
                     CustomData.SequenceEqual(input.CustomData))
                ) &&
                (
                    FilePrefix == input.FilePrefix ||
                    (FilePrefix != null &&
                     FilePrefix.Equals(input.FilePrefix))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallRoutingRecording {\n");
            sb.Append("  RecordingType: ").Append(RecordingType).Append("\n");
            sb.Append("  RecordingComposition: ").Append(RecordingComposition).Append("\n");
            sb.Append("  CustomData: ").Append(CustomData).Append("\n");
            sb.Append("  FilePrefix: ").Append(FilePrefix).Append("\n");
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
            return Equals(input as CallRoutingRecording);
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
                hashCode = hashCode * 59 + RecordingType.GetHashCode();
                if (RecordingComposition != null)
                    hashCode = hashCode * 59 + RecordingComposition.GetHashCode();
                if (CustomData != null)
                    hashCode = hashCode * 59 + CustomData.GetHashCode();
                if (FilePrefix != null)
                    hashCode = hashCode * 59 + FilePrefix.GetHashCode();
                return hashCode;
            }
        }
    }
}