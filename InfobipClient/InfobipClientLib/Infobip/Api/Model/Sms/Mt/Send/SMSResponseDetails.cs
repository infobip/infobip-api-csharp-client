using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSResponseDetails
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("smsCount")]
        public int? SmsCount { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }


    }
}