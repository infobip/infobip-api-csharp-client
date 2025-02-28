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
    ///     CallsSingleBody
    /// </summary>
    [DataContract(Name = "CallsSingleBody")]
    [JsonObject]
    public class CallsSingleBody : IEquatable<CallsSingleBody>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsSingleBody" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsSingleBody()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsSingleBody" /> class.
        /// </summary>
        /// <param name="audioFileUrl">
        ///     An audio file can be delivered as a voice message to the recipients. An audio file must be
        ///     uploaded online, so that the existing URL can be available for file download. Size of the audio file must be below
        ///     4 MB. Supported formats of the provided file are mp3 and wav. Our platform needs to have permission to make GET and
        ///     HEAD HTTP requests on the provided URL. Standard http ports (like 80, 8080, etc.) are advised..
        /// </param>
        /// <param name="from">
        ///     Numeric sender ID in E.164 standard format (Example: 41793026727). This is caller ID that will be
        ///     presented to the end user where applicable. (required).
        /// </param>
        /// <param name="language">
        ///     If the message is in text format, the language in which the message is written must be defined
        ///     for correct pronunciation. More about Text-to-speech functionality and supported TTS languages can be found
        ///     [here](https://www.infobip.com/docs/voice-and-video/outbound-calls#text-to-speech-voice-over-broadcast). If not
        ///     set, default language is &#x60;English [en]&#x60;. If voice is not set, then default voice for that specific
        ///     language is used. In the case of English language, the voice is &#x60;[Joanna]&#x60;..
        /// </param>
        /// <param name="text">
        ///     Message to be converted to speech and played to subscribers. Message text can be up to 1400
        ///     characters long and cannot contain only punctuation. SSML (_Speech Synthesis Markup Language_) is supported and can
        ///     be used to fully customize pronunciation of the provided text..
        /// </param>
        /// <param name="to">
        ///     Phone number of the recipient. Phone number must be written in E.164 standard format (Example:
        ///     41793026727). (required).
        /// </param>
        /// <param name="voice">voice.</param>
        public CallsSingleBody(string audioFileUrl = default, string from = default, string language = default,
            string text = default, string to = default, CallsVoice voice = default)
        {
            // to ensure "from" is required (not null)
            From = from ?? throw new ArgumentNullException("from");
            // to ensure "to" is required (not null)
            To = to ?? throw new ArgumentNullException("to");
            AudioFileUrl = audioFileUrl;
            Language = language;
            Text = text;
            Voice = voice;
        }

        /// <summary>
        ///     An audio file can be delivered as a voice message to the recipients. An audio file must be uploaded online, so that
        ///     the existing URL can be available for file download. Size of the audio file must be below 4 MB. Supported formats
        ///     of the provided file are mp3 and wav. Our platform needs to have permission to make GET and HEAD HTTP requests on
        ///     the provided URL. Standard http ports (like 80, 8080, etc.) are advised.
        /// </summary>
        /// <value>
        ///     An audio file can be delivered as a voice message to the recipients. An audio file must be uploaded online, so
        ///     that the existing URL can be available for file download. Size of the audio file must be below 4 MB. Supported
        ///     formats of the provided file are mp3 and wav. Our platform needs to have permission to make GET and HEAD HTTP
        ///     requests on the provided URL. Standard http ports (like 80, 8080, etc.) are advised.
        /// </value>
        [DataMember(Name = "audioFileUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "audioFileUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("audioFileUrl")]
        public string AudioFileUrl { get; set; }

        /// <summary>
        ///     Numeric sender ID in E.164 standard format (Example: 41793026727). This is caller ID that will be presented to the
        ///     end user where applicable.
        /// </summary>
        /// <value>
        ///     Numeric sender ID in E.164 standard format (Example: 41793026727). This is caller ID that will be presented to
        ///     the end user where applicable.
        /// </value>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "from", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("from")]
        public string From { get; set; }

        /// <summary>
        ///     If the message is in text format, the language in which the message is written must be defined for correct
        ///     pronunciation. More about Text-to-speech functionality and supported TTS languages can be found
        ///     [here](https://www.infobip.com/docs/voice-and-video/outbound-calls#text-to-speech-voice-over-broadcast). If not
        ///     set, default language is &#x60;English [en]&#x60;. If voice is not set, then default voice for that specific
        ///     language is used. In the case of English language, the voice is &#x60;[Joanna]&#x60;.
        /// </summary>
        /// <value>
        ///     If the message is in text format, the language in which the message is written must be defined for correct
        ///     pronunciation. More about Text-to-speech functionality and supported TTS languages can be found
        ///     [here](https://www.infobip.com/docs/voice-and-video/outbound-calls#text-to-speech-voice-over-broadcast). If not
        ///     set, default language is &#x60;English [en]&#x60;. If voice is not set, then default voice for that specific
        ///     language is used. In the case of English language, the voice is &#x60;[Joanna]&#x60;.
        /// </value>
        [DataMember(Name = "language", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "language", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        ///     Message to be converted to speech and played to subscribers. Message text can be up to 1400 characters long and
        ///     cannot contain only punctuation. SSML (_Speech Synthesis Markup Language_) is supported and can be used to fully
        ///     customize pronunciation of the provided text.
        /// </summary>
        /// <value>
        ///     Message to be converted to speech and played to subscribers. Message text can be up to 1400 characters long and
        ///     cannot contain only punctuation. SSML (_Speech Synthesis Markup Language_) is supported and can be used to fully
        ///     customize pronunciation of the provided text.
        /// </value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Phone number of the recipient. Phone number must be written in E.164 standard format (Example: 41793026727).
        /// </summary>
        /// <value>Phone number of the recipient. Phone number must be written in E.164 standard format (Example: 41793026727).</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "to", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        /// <summary>
        ///     Gets or Sets Voice
        /// </summary>
        [DataMember(Name = "voice", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "voice", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("voice")]
        public CallsVoice Voice { get; set; }

        /// <summary>
        ///     Returns true if CallsSingleBody instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsSingleBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsSingleBody input)
        {
            if (input == null)
                return false;

            return
                (
                    AudioFileUrl == input.AudioFileUrl ||
                    (AudioFileUrl != null &&
                     AudioFileUrl.Equals(input.AudioFileUrl))
                ) &&
                (
                    From == input.From ||
                    (From != null &&
                     From.Equals(input.From))
                ) &&
                (
                    Language == input.Language ||
                    (Language != null &&
                     Language.Equals(input.Language))
                ) &&
                (
                    Text == input.Text ||
                    (Text != null &&
                     Text.Equals(input.Text))
                ) &&
                (
                    To == input.To ||
                    (To != null &&
                     To.Equals(input.To))
                ) &&
                (
                    Voice == input.Voice ||
                    (Voice != null &&
                     Voice.Equals(input.Voice))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsSingleBody {\n");
            sb.Append("  AudioFileUrl: ").Append(AudioFileUrl).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Voice: ").Append(Voice).Append("\n");
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
            return Equals(input as CallsSingleBody);
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
                if (AudioFileUrl != null)
                    hashCode = hashCode * 59 + AudioFileUrl.GetHashCode();
                if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                if (Language != null)
                    hashCode = hashCode * 59 + Language.GetHashCode();
                if (Text != null)
                    hashCode = hashCode * 59 + Text.GetHashCode();
                if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                if (Voice != null)
                    hashCode = hashCode * 59 + Voice.GetHashCode();
                return hashCode;
            }
        }
    }
}