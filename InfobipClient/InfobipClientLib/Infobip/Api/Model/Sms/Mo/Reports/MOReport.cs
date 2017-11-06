using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Sms.Mo.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOReport
    {
        [JsonProperty("cleanText")]
        public string CleanText { get; set; }

        [JsonProperty("smsCount")]
        public int SmsCount { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

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