using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Send;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Configuration
    {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }


    }
}