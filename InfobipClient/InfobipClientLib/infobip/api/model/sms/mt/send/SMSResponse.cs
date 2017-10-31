using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("trackingProcessKey")]
        public string TrackingProcessKey { get; set; }

        [JsonProperty("messages")]
        public List<SMSResponseDetails> Messages { get; set; } = new List<SMSResponseDetails>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSResponse;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<string>.Default.Equals(TrackingProcessKey, thisClass.TrackingProcessKey) &&
                EqualityComparer<List<SMSResponseDetails>>.Default.Equals(Messages, thisClass.Messages);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(TrackingProcessKey);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<SMSResponseDetails>>.Default.GetHashCode(Messages);
            return hashCode;
        }
    }
}