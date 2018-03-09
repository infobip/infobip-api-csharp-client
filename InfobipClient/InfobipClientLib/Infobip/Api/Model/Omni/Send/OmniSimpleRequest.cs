using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OmniSimpleRequest
    {
        [JsonProperty("destinations")]
        public IList<Destination> Destinations { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("scenarioKey")]
        public string ScenarioKey { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("mailSubject")]
        public string MailSubject { get; set; }


    }
}