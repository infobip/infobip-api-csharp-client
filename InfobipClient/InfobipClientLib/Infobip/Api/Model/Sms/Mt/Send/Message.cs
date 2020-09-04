using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Send;
using Newtonsoft.Json;
using Infobip.Api.Config;
using Infobip.Api.Model.Sms.Mt.Send.Binary;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Message
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public IList<string> To { get; set; }

        [JsonProperty("destinations")]
        public IList<Destination> Destinations { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("binary")]
        public BinaryContent Binary { get; set; }

        [JsonProperty("flash")]
        public bool? Flash { get; set; }

        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        [JsonProperty("notify")]
        public bool? Notify { get; set; }

        [JsonProperty("intermediateReport")]
        public bool? IntermediateReport { get; set; }

        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }

        [JsonProperty("callbackData")]
        public string CallbackData { get; set; }

        [JsonProperty("validityPeriod")]
        public long? ValidityPeriod { get; set; }

        [JsonProperty("sendAt")]
        public FormattedDate SendAt { get; set; }

        [JsonProperty("deliveryTimeWindow")]
        public DeliveryTimeWindow DeliveryTimeWindow { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("operatorClientId")]
        public string OperatorClientId { get; set; }

        [JsonProperty("regional")]
        public RegionalOptions Regional { get; set; }

    }
}