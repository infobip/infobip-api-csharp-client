using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using System;

namespace Infobip.Api.Model.Sms.Mo.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetReceivedSmsLogsExecuteContext
    {
        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("receivedSince")]
        public FormattedDate ReceivedSince { get; set; }

        [JsonProperty("receivedUntil")]
        public FormattedDate ReceivedUntil { get; set; }


    }
}