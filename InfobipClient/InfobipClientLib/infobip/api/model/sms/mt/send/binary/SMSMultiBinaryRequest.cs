using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSMultiBinaryRequest
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; } = new List<Message>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSMultiBinaryRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<List<Message>>.Default.Equals(Messages, thisClass.Messages);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<Message>>.Default.GetHashCode(Messages);
            return hashCode;
        }
    }
}