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
    ///     CallsDtmfCaptureRequest
    /// </summary>
    [DataContract(Name = "CallsDtmfCaptureRequest")]
    [JsonObject]
    public class CallsDtmfCaptureRequest : IEquatable<CallsDtmfCaptureRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsDtmfCaptureRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsDtmfCaptureRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsDtmfCaptureRequest" /> class.
        /// </summary>
        /// <param name="maxLength">Maximum number of digits to capture. (required).</param>
        /// <param name="timeout">The duration, in milliseconds, to wait for the first DTMF digit response. (required).</param>
        /// <param name="terminator">Digit used to end input if less than &#x60;maxLength&#x60; digits have been pressed..</param>
        /// <param name="digitTimeout">
        ///     Duration, in milliseconds, to wait for a DTMF digit in-between individual digit inputs. If
        ///     not set, &#x60;digitTimeout&#x60; will use the same duration as &#x60;timeout&#x60;..
        /// </param>
        /// <param name="playContent">playContent.</param>
        /// <param name="customData">Optional parameter to update a call&#39;s custom data..</param>
        public CallsDtmfCaptureRequest(int maxLength = default, int timeout = default, string terminator = default,
            int digitTimeout = default, CallsPlayContent playContent = default,
            Dictionary<string, string> customData = default)
        {
            MaxLength = maxLength;
            Timeout = timeout;
            Terminator = terminator;
            DigitTimeout = digitTimeout;
            PlayContent = playContent;
            CustomData = customData;
        }

        /// <summary>
        ///     Maximum number of digits to capture.
        /// </summary>
        /// <value>Maximum number of digits to capture.</value>
        [DataMember(Name = "maxLength", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "maxLength", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("maxLength")]
        public int MaxLength { get; set; }

        /// <summary>
        ///     The duration, in milliseconds, to wait for the first DTMF digit response.
        /// </summary>
        /// <value>The duration, in milliseconds, to wait for the first DTMF digit response.</value>
        [DataMember(Name = "timeout", IsRequired = true, EmitDefaultValue = true)]
        [JsonProperty(PropertyName = "timeout", Required = Required.DisallowNull,
            DefaultValueHandling = DefaultValueHandling.Include)]
        [JsonPropertyName("timeout")]
        public int Timeout { get; set; }

        /// <summary>
        ///     Digit used to end input if less than &#x60;maxLength&#x60; digits have been pressed.
        /// </summary>
        /// <value>Digit used to end input if less than &#x60;maxLength&#x60; digits have been pressed.</value>
        [DataMember(Name = "terminator", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "terminator", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("terminator")]
        public string Terminator { get; set; }

        /// <summary>
        ///     Duration, in milliseconds, to wait for a DTMF digit in-between individual digit inputs. If not set, &#x60;
        ///     digitTimeout&#x60; will use the same duration as &#x60;timeout&#x60;.
        /// </summary>
        /// <value>
        ///     Duration, in milliseconds, to wait for a DTMF digit in-between individual digit inputs. If not set, &#x60;
        ///     digitTimeout&#x60; will use the same duration as &#x60;timeout&#x60;.
        /// </value>
        [DataMember(Name = "digitTimeout", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "digitTimeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("digitTimeout")]
        public int DigitTimeout { get; set; }

        /// <summary>
        ///     Gets or Sets PlayContent
        /// </summary>
        [DataMember(Name = "playContent", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "playContent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("playContent")]
        public CallsPlayContent PlayContent { get; set; }

        /// <summary>
        ///     Optional parameter to update a call&#39;s custom data.
        /// </summary>
        /// <value>Optional parameter to update a call&#39;s custom data.</value>
        [DataMember(Name = "customData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonPropertyName("customData")]
        public Dictionary<string, string> CustomData { get; set; }

        /// <summary>
        ///     Returns true if CallsDtmfCaptureRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsDtmfCaptureRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsDtmfCaptureRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    MaxLength == input.MaxLength ||
                    MaxLength.Equals(input.MaxLength)
                ) &&
                (
                    Timeout == input.Timeout ||
                    Timeout.Equals(input.Timeout)
                ) &&
                (
                    Terminator == input.Terminator ||
                    (Terminator != null &&
                     Terminator.Equals(input.Terminator))
                ) &&
                (
                    DigitTimeout == input.DigitTimeout ||
                    DigitTimeout.Equals(input.DigitTimeout)
                ) &&
                (
                    PlayContent == input.PlayContent ||
                    (PlayContent != null &&
                     PlayContent.Equals(input.PlayContent))
                ) &&
                (
                    CustomData == input.CustomData ||
                    (CustomData != null &&
                     input.CustomData != null &&
                     CustomData.SequenceEqual(input.CustomData))
                );
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsDtmfCaptureRequest {\n");
            sb.Append("  MaxLength: ").Append(MaxLength).Append("\n");
            sb.Append("  Timeout: ").Append(Timeout).Append("\n");
            sb.Append("  Terminator: ").Append(Terminator).Append("\n");
            sb.Append("  DigitTimeout: ").Append(DigitTimeout).Append("\n");
            sb.Append("  PlayContent: ").Append(PlayContent).Append("\n");
            sb.Append("  CustomData: ").Append(CustomData).Append("\n");
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
            return Equals(input as CallsDtmfCaptureRequest);
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
                hashCode = hashCode * 59 + MaxLength.GetHashCode();
                hashCode = hashCode * 59 + Timeout.GetHashCode();
                if (Terminator != null)
                    hashCode = hashCode * 59 + Terminator.GetHashCode();
                hashCode = hashCode * 59 + DigitTimeout.GetHashCode();
                if (PlayContent != null)
                    hashCode = hashCode * 59 + PlayContent.GetHashCode();
                if (CustomData != null)
                    hashCode = hashCode * 59 + CustomData.GetHashCode();
                return hashCode;
            }
        }
    }
}