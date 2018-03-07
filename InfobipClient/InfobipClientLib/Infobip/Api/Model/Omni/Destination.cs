using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni;
using System;

namespace Infobip.Api.Model.Omni
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Destination
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("to")]
        public To To { get; set; }


    }
}