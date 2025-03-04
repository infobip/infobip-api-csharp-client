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
    ///     CallsRecordingRequest
    /// </summary>
    [DataContract(Name = "CallsRecordingRequest")]
    [JsonObject]
    public class CallsRecordingRequest : IEquatable<CallsRecordingRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsRecordingRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsRecordingRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsRecordingRequest" /> class.
        /// </summary>
        /// <param name="recordingType">recordingType (required).</param>
        /// <param name="maxSilence">
        ///     Silence duration, in seconds, before the recording stops. (If this field is set the recording
        ///     can&#39;t be stopped by the [stop recording endpoint](#call-stop-recording).).
        /// </param>
        /// <param name="beep">Flag indicating if a beep sound should be played before recording. (default to false).</param>
        /// <param name="maxDuration">
        ///     Maximum recording duration in seconds.  (If this field is set the recording can&#39;t be
        ///     stopped by the [stop recording endpoint](#call-stop-recording).).
        /// </param>
        /// <param name="customData">Custom data..</param>
        /// <param name="filePrefix">
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on
        ///     [Voice settings page](https://portal.infobip.com/apps/voice/recording/settings). Using the same &#x60;filePrefix
        ///     &#x60; will override the files on the SFTP server..
        /// </param>
        public CallsRecordingRequest(CallsRecordingType recordingType = default, int maxSilence = default,
            bool beep = false, int maxDuration = default, Dictionary<string, string> customData = default,
            string filePrefix = default)
        {
            RecordingType = recordingType;
            MaxSilence = maxSilence;
            Beep = beep;
            MaxDuration = maxDuration;
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
        public CallsRecordingType RecordingType { get; set; }

        /// <summary>
        ///     Silence duration, in seconds, before the recording stops. (If this field is set the recording can&#39;t be stopped
        ///     by the [stop recording endpoint](#call-stop-recording).)
        /// </summary>
        /// <value>
        ///     Silence duration, in seconds, before the recording stops. (If this field is set the recording can&#39;t be
        ///     stopped by the [stop recording endpoint](#call-stop-recording).)
        /// </value>
        [DataMember(Name = "maxSilence", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxSilence", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("maxSilence")]
        public int MaxSilence { get; set; }

        /// <summary>
        ///     Flag indicating if a beep sound should be played before recording.
        /// </summary>
        /// <value>Flag indicating if a beep sound should be played before recording.</value>
        [DataMember(Name = "beep", EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "beep", DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("beep")]
        public bool Beep { get; set; }

        /// <summary>
        ///     Maximum recording duration in seconds.  (If this field is set the recording can&#39;t be stopped by the [stop
        ///     recording endpoint](#call-stop-recording).)
        /// </summary>
        /// <value>
        ///     Maximum recording duration in seconds.  (If this field is set the recording can&#39;t be stopped by the [stop
        ///     recording endpoint](#call-stop-recording).)
        /// </value>
        [DataMember(Name = "maxDuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxDuration", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; }

        /// <summary>
        ///     Custom data.
        /// </summary>
        /// <value>Custom data.</value>
        [DataMember(Name = "customData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("customData")]
        public Dictionary<string, string> CustomData { get; set; }

        /// <summary>
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on [Voice settings
        ///     page](https://portal.infobip.com/apps/voice/recording/settings). Using the same &#x60;filePrefix&#x60; will
        ///     override the files on the SFTP server.
        /// </summary>
        /// <value>
        ///     Custom name for the recording&#39;s zip file. Applicable only when SFTP server is enabled on [Voice settings
        ///     page](https://portal.infobip.com/apps/voice/recording/settings). Using the same &#x60;filePrefix&#x60; will
        ///     override the files on the SFTP server.
        /// </value>
        [DataMember(Name = "filePrefix", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filePrefix", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("filePrefix")]
        public string FilePrefix { get; set; }

        /// <summary>
        ///     Returns true if CallsRecordingRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsRecordingRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsRecordingRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    RecordingType == input.RecordingType ||
                    RecordingType.Equals(input.RecordingType)
                ) &&
                (
                    MaxSilence == input.MaxSilence ||
                    MaxSilence.Equals(input.MaxSilence)
                ) &&
                (
                    Beep == input.Beep ||
                    Beep.Equals(input.Beep)
                ) &&
                (
                    MaxDuration == input.MaxDuration ||
                    MaxDuration.Equals(input.MaxDuration)
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
            sb.Append("class CallsRecordingRequest {\n");
            sb.Append("  RecordingType: ").Append(RecordingType).Append("\n");
            sb.Append("  MaxSilence: ").Append(MaxSilence).Append("\n");
            sb.Append("  Beep: ").Append(Beep).Append("\n");
            sb.Append("  MaxDuration: ").Append(MaxDuration).Append("\n");
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
            return Equals(input as CallsRecordingRequest);
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
                hashCode = hashCode * 59 + MaxSilence.GetHashCode();
                hashCode = hashCode * 59 + Beep.GetHashCode();
                hashCode = hashCode * 59 + MaxDuration.GetHashCode();
                if (CustomData != null)
                    hashCode = hashCode * 59 + CustomData.GetHashCode();
                if (FilePrefix != null)
                    hashCode = hashCode * 59 + FilePrefix.GetHashCode();
                return hashCode;
            }
        }
    }
}