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
    public class OmniLog
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("sentAt")]
        public FormattedDate SentAt { get; set; }

        [JsonProperty("doneAt")]
        public FormattedDate DoneAt { get; set; }

        [JsonProperty("messageCount")]
        public int? MessageCount { get; set; }

        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("channel")]
        public OmniChannel Channel { get; set; }


    }
}