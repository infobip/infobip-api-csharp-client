using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Sms.Mt.Send.Binary;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSBinaryRequest
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public IList<string> To { get; set; }

        [JsonProperty("binary")]
        public BinaryContent Binary { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("operatorClientId")]
        public string OperatorClientId { get; set; }


    }
}