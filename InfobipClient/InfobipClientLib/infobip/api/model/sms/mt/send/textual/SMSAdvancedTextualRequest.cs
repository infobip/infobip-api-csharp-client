using System.Collections.Generic;
using Newtonsoft.Json;
using InfobipClient.infobip.api.model.sms.mt.send;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.textual
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSAdvancedTextualRequest
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; } = new List<Message>();

        [JsonProperty("tracking")]
        public Tracking Tracking { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSAdvancedTextualRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<List<Message>>.Default.Equals(Messages, thisClass.Messages) &&
                EqualityComparer<Tracking>.Default.Equals(Tracking, thisClass.Tracking);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<Message>>.Default.GetHashCode(Messages);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Tracking>.Default.GetHashCode(Tracking);
            return hashCode;
        }
    }
}