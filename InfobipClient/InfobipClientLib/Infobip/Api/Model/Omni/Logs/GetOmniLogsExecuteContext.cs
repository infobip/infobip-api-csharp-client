using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using Infobip.Api.Model.Omni;
using System;

namespace Infobip.Api.Model.Omni.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetOmniLogsExecuteContext
    {
        [JsonProperty("sentUntil")]
        public FormattedDate SentUntil { get; set; }

        [JsonProperty("messageId")]
        public string[] MessageId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("channel")]
        public OmniChannel Channel { get; set; }

        [JsonProperty("generalStatus")]
        public string GeneralStatus { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("sentSince")]
        public FormattedDate SentSince { get; set; }

        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("bulkId")]
        public string[] BulkId { get; set; }

        [JsonProperty("mnc")]
        public string Mnc { get; set; }


    }
}