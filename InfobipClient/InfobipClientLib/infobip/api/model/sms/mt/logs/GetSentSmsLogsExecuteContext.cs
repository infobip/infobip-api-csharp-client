using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using System;

namespace Infobip.Api.Model.Sms.Mt.Logs
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


    }
}