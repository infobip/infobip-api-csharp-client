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
using Newtonsoft.Json;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Infobip.Api.Client.Model
{
    /// <summary>
    ///     CallsProviderSipTrunkUpdateRequest
    /// </summary>
    [DataContract(Name = "CallsProviderSipTrunkUpdateRequest")]
    [JsonObject]
    public class CallsProviderSipTrunkUpdateRequest : CallsSipTrunkUpdateRequest,
        IEquatable<CallsProviderSipTrunkUpdateRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsProviderSipTrunkUpdateRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallsProviderSipTrunkUpdateRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallsProviderSipTrunkUpdateRequest" /> class.
        /// </summary>
        /// <param name="type">type (default to CallsSipTrunkType.Provider).</param>
        /// <param name="name">SIP trunk name. (required).</param>
        /// <param name="internationalCallsAllowed">
        ///     Indicates whether international calls should be allowed. Calls between
        ///     different countries are considered international. (default to false).
        /// </param>
        /// <param name="channelLimit">Maximum number of concurrent channels..</param>
        public CallsProviderSipTrunkUpdateRequest(CallsSipTrunkType? type = CallsSipTrunkType.Provider,
            string name = default, bool internationalCallsAllowed = false, int channelLimit = default) : base(type,
            name, internationalCallsAllowed, channelLimit)
        {
        }

        /// <summary>
        ///     Returns true if CallsProviderSipTrunkUpdateRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CallsProviderSipTrunkUpdateRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallsProviderSipTrunkUpdateRequest input)
        {
            if (input == null)
                return false;

            return base.Equals(input);
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallsProviderSipTrunkUpdateRequest {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return Equals(input as CallsProviderSipTrunkUpdateRequest);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = base.GetHashCode();
            return hashCode;
        }
    }
}