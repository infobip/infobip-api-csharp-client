using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mo.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOLog
    {
        [JsonProperty("cleanText")]
        public string CleanText { get; set; }

        [JsonProperty("smsCount")]
        public int? SmsCount { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("receivedAt")]
        public DateTimeOffset ReceivedAt { get; set; }


    }
}