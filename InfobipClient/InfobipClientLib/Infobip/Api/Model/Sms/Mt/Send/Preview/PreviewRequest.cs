using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class PreviewRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }


    }
}