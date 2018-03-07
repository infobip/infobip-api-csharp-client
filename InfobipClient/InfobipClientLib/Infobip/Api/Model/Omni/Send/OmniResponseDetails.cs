using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OmniResponseDetails
    {
        [JsonProperty("to")]
        public To To { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }


    }
}