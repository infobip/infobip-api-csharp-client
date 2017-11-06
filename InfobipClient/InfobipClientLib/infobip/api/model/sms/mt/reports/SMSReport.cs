using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Sms.Mt.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSReport
    {
        [JsonProperty("doneAt")]
        public DateTimeOffset DoneAt { get; set; }

        [JsonProperty("smsCount")]
        public int? SmsCount { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("sentAt")]
        public DateTimeOffset SentAt { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }


    }
}