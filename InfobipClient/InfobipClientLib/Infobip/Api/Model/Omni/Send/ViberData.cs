using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class ViberData
    {
        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }

        [JsonProperty("buttonURL")]
        public string ButtonURL { get; set; }

        [JsonProperty("isPromotional")]
        public bool IsPromotional { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("validityPeriod")]
        public long? ValidityPeriod { get; set; }

        [JsonProperty("validityPeriodTimeUnit")]
        public TimeUnit ValidityPeriodTimeUnit { get; set; }


    }
}