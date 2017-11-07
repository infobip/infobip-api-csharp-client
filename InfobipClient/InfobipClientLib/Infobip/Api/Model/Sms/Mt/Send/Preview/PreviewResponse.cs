using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class PreviewResponse
    {
        [JsonProperty("originalText")]
        public string OriginalText { get; set; }

        [JsonProperty("previews")]
        public List<Preview> Previews { get; set; }


    }
}