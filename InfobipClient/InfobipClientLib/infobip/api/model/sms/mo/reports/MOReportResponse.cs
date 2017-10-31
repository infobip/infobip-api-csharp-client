using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mo.reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOReportResponse
    {
        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        [JsonProperty("pendingMessageCount")]
        public int PendingMessageCount { get; set; }

        [JsonProperty("results")]
        public List<MOReport> Results { get; set; } = new List<MOReport>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as MOReportResponse;
            return thisClass != null &&
                EqualityComparer<int>.Default.Equals(MessageCount, thisClass.MessageCount) &&
                EqualityComparer<int>.Default.Equals(PendingMessageCount, thisClass.PendingMessageCount) &&
                EqualityComparer<List<MOReport>>.Default.Equals(Results, thisClass.Results);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<int>.Default.GetHashCode(MessageCount);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int>.Default.GetHashCode(PendingMessageCount);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<MOReport>>.Default.GetHashCode(Results);
            return hashCode;
        }
    }
}