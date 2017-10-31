using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Destination
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Destination;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(MessageId, thisClass.MessageId) &&
                EqualityComparer<string>.Default.Equals(To, thisClass.To);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(MessageId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(To);
            return hashCode;
        }
    }
}