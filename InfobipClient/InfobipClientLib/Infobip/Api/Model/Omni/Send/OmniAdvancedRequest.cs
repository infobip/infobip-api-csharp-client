using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using Infobip.Api.Model.Omni;
using Infobip.Api.Model.Omni.Send;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OmniAdvancedRequest
    {
        [JsonProperty("destinations")]
        public IList<Destination> Destinations { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("scenarioKey")]
        public string ScenarioKey { get; set; }

        [JsonProperty("sms")]
        public SmsData Sms { get; set; }

        [JsonProperty("parseco")]
        public ParsecoData Parseco { get; set; }

        [JsonProperty("viber")]
        public ViberData Viber { get; set; }

        [JsonProperty("voice")]
        public VoiceData Voice { get; set; }

        [JsonProperty("email")]
        public EmailData Email { get; set; }

        [JsonProperty("push")]
        public PushData Push { get; set; }

        [JsonProperty("facebook")]
        public FacebookData Facebook { get; set; }

        [JsonProperty("line")]
        public LineData Line { get; set; }

        [JsonProperty("vKontakte")]
        public VKontakteData VKontakte { get; set; }

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

        [JsonProperty("sendAt")]
        public FormattedDate SendAt { get; set; }


    }
}