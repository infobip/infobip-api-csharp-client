using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mo.Reports
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
        public List<MOReport> Results { get; set; }


    }
}