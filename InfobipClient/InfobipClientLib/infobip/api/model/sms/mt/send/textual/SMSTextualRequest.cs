using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.textual
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSTextualRequest
    {
        [JsonProperty("operatorClientId")]
        public string OperatorClientId { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSTextualRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(OperatorClientId, thisClass.OperatorClientId) &&
                EqualityComparer<string>.Default.Equals(CampaignId, thisClass.CampaignId) &&
                EqualityComparer<string>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<List<string>>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Text, thisClass.Text) &&
                EqualityComparer<string>.Default.Equals(Transliteration, thisClass.Transliteration);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(OperatorClientId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CampaignId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<string>>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Transliteration);
            return hashCode;
        }
    }
}