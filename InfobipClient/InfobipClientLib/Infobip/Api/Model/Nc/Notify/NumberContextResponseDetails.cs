using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Nc.Notify
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextResponseDetails
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }


    }
}