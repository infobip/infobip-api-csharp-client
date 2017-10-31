using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetSentSmsDeliveryReportsExecuteContext
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as GetSentSmsDeliveryReportsExecuteContext;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<int?>.Default.Equals(Limit, thisClass.Limit) &&
                EqualityComparer<string>.Default.Equals(MessageId, thisClass.MessageId);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Limit);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(MessageId);
            return hashCode;
        }
    }
}