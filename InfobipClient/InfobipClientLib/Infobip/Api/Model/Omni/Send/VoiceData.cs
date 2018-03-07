using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class VoiceData
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("validityPeriod")]
        public long? ValidityPeriod { get; set; }

        [JsonProperty("validityPeriodTimeUnit")]
        public TimeUnit ValidityPeriodTimeUnit { get; set; }


    }
}