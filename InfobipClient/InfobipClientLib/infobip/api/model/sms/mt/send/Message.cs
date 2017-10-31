using InfobipClient.infobip.api.model.sms.mt.send.binary;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
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

        public override bool Equals(object obj)
        {
            var thisClass = obj as Message;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(CampaignId, thisClass.CampaignId) &&
                EqualityComparer<List<Destination>>.Default.Equals(Destinations, thisClass.Destinations) &&
                EqualityComparer<Language>.Default.Equals(Language, thisClass.Language) &&
                EqualityComparer<DeliveryTimeWindow>.Default.Equals(DeliveryTimeWindow, thisClass.DeliveryTimeWindow) &&
                EqualityComparer<bool?>.Default.Equals(Notify, thisClass.Notify) &&
                EqualityComparer<string>.Default.Equals(NotifyContentType, thisClass.NotifyContentType) &&
                EqualityComparer<long?>.Default.Equals(ValidityPeriod, thisClass.ValidityPeriod) &&
                EqualityComparer<string>.Default.Equals(OperatorClientId, thisClass.OperatorClientId) &&
                EqualityComparer<BinaryContent>.Default.Equals(Binary, thisClass.Binary) &&
                EqualityComparer<string>.Default.Equals(CallbackData, thisClass.CallbackData) &&
                EqualityComparer<string>.Default.Equals(NotifyUrl, thisClass.NotifyUrl) &&
                EqualityComparer<string>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<List<string>>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Text, thisClass.Text) &&
                EqualityComparer<DateTimeOffset>.Default.Equals(SendAt, thisClass.SendAt) &&
                EqualityComparer<string>.Default.Equals(Transliteration, thisClass.Transliteration) &&
                EqualityComparer<bool?>.Default.Equals(Flash, thisClass.Flash) &&
                EqualityComparer<bool?>.Default.Equals(IntermediateReport, thisClass.IntermediateReport);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CampaignId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<Destination>>.Default.GetHashCode(Destinations);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Language>.Default.GetHashCode(Language);
            hashCode = hashCode * -1521134295 +  EqualityComparer<DeliveryTimeWindow>.Default.GetHashCode(DeliveryTimeWindow);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(Notify);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NotifyContentType);
            hashCode = hashCode * -1521134295 +  EqualityComparer<long?>.Default.GetHashCode(ValidityPeriod);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(OperatorClientId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<BinaryContent>.Default.GetHashCode(Binary);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CallbackData);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NotifyUrl);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<string>>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 +  EqualityComparer<DateTimeOffset>.Default.GetHashCode(SendAt);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Transliteration);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(Flash);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(IntermediateReport);
            return hashCode;
        }
    }
}