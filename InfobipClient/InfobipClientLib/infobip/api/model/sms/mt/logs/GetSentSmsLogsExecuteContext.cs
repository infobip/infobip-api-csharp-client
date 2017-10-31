using System.Collections.Generic;
using Newtonsoft.Json;
using InfobipClient.infobip.api.config;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetSentSmsLogsExecuteContext
    {
        [JsonProperty("generalStatus")]
        public string GeneralStatus { get; set; }

        [JsonProperty("mnc")]
        public string Mnc { get; set; }

        [JsonProperty("sentUntil")]
        public FormattedDate SentUntil { get; set; }

        [JsonProperty("bulkId")]
        public string[] BulkId { get; set; }

        [JsonProperty("sentSince")]
        public FormattedDate SentSince { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("messageId")]
        public string[] MessageId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as GetSentSmsLogsExecuteContext;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(GeneralStatus, thisClass.GeneralStatus) &&
                EqualityComparer<string>.Default.Equals(Mnc, thisClass.Mnc) &&
                EqualityComparer<FormattedDate>.Default.Equals(SentUntil, thisClass.SentUntil) &&
                EqualityComparer<string[]>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<FormattedDate>.Default.Equals(SentSince, thisClass.SentSince) &&
                EqualityComparer<int?>.Default.Equals(Limit, thisClass.Limit) &&
                EqualityComparer<string[]>.Default.Equals(MessageId, thisClass.MessageId) &&
                EqualityComparer<string>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<string>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Mcc, thisClass.Mcc);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(GeneralStatus);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Mnc);
            hashCode = hashCode * -1521134295 +  EqualityComparer<FormattedDate>.Default.GetHashCode(SentUntil);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string[]>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<FormattedDate>.Default.GetHashCode(SentSince);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Limit);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string[]>.Default.GetHashCode(MessageId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Mcc);
            return hashCode;
        }
    }
}