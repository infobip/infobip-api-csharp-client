using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSBinaryRequest
    {
        [JsonProperty("operatorClientId")]
        public string OperatorClientId { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("binary")]
        public BinaryContent Binary { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();


    }
}