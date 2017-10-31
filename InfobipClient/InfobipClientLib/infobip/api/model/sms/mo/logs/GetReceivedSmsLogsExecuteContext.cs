using System.Collections.Generic;
using Newtonsoft.Json;
using InfobipClient.infobip.api.config;
using System;

namespace InfobipClient.infobip.api.model.sms.mo.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetReceivedSmsLogsExecuteContext
    {
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("receivedSince")]
        public FormattedDate ReceivedSince { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("receivedUntil")]
        public FormattedDate ReceivedUntil { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as GetReceivedSmsLogsExecuteContext;
            return thisClass != null &&
                EqualityComparer<int?>.Default.Equals(Limit, thisClass.Limit) &&
                EqualityComparer<FormattedDate>.Default.Equals(ReceivedSince, thisClass.ReceivedSince) &&
                EqualityComparer<string>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Keyword, thisClass.Keyword) &&
                EqualityComparer<FormattedDate>.Default.Equals(ReceivedUntil, thisClass.ReceivedUntil);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Limit);
            hashCode = hashCode * -1521134295 +  EqualityComparer<FormattedDate>.Default.GetHashCode(ReceivedSince);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Keyword);
            hashCode = hashCode * -1521134295 +  EqualityComparer<FormattedDate>.Default.GetHashCode(ReceivedUntil);
            return hashCode;
        }
    }
}