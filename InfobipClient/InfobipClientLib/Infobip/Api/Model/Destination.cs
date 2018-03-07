using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Destination
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }


    }
}