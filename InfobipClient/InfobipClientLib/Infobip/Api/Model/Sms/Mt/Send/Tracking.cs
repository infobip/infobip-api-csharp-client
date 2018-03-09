using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Tracking
    {
        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }


    }
}