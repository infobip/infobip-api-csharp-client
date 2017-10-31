using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.binary
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

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSBinaryRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(OperatorClientId, thisClass.OperatorClientId) &&
                EqualityComparer<string>.Default.Equals(CampaignId, thisClass.CampaignId) &&
                EqualityComparer<BinaryContent>.Default.Equals(Binary, thisClass.Binary) &&
                EqualityComparer<string>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<List<string>>.Default.Equals(To, thisClass.To);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(OperatorClientId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CampaignId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<BinaryContent>.Default.GetHashCode(Binary);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<string>>.Default.GetHashCode(To);
            return hashCode;
        }
    }
}