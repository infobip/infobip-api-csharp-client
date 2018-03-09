using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model.Sms.Mo.Reports;

namespace Infobip.Api.Model.Sms.Mo.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOReportResponse
    {
        [JsonProperty("results")]
        public IList<MOReport> Results { get; set; }

        [JsonProperty("messageCount")]
        public int MessageCount { get; set; }

        [JsonProperty("pendingMessageCount")]
        public int PendingMessageCount { get; set; }


    }
}