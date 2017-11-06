using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Sms.Mt.Send.Binary;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Message
    {
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("destinations")]
        public List<Destination> Destinations { get; set; } = new List<Destination>();

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("deliveryTimeWindow")]
        public DeliveryTimeWindow DeliveryTimeWindow { get; set; }

        [JsonProperty("notify")]
        public bool? Notify { get; set; }

        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }

        [JsonProperty("validityPeriod")]
        public long? ValidityPeriod { get; set; }

        [JsonProperty("operatorClientId")]
        public string OperatorClientId { get; set; }

        [JsonProperty("binary")]
        public BinaryContent Binary { get; set; }

        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        [JsonProperty("flash")]
        public bool? Flash { get; set; }

        [JsonProperty("intermediateReport")]
        public bool? IntermediateReport { get; set; }


    }
}