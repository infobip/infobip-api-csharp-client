using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Send.Preview;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Preview
    {
        [JsonProperty("textPreview")]
        public string TextPreview { get; set; }

        [JsonProperty("messageCount")]
        public int? MessageCount { get; set; }

        [JsonProperty("charactersRemaining")]
        public int? CharactersRemaining { get; set; }

        [JsonProperty("configuration")]
        public Configuration Configuration { get; set; }


    }
}