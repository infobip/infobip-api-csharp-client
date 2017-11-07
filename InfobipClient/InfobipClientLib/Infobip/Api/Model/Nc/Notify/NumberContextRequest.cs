using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc.Notify
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextRequest
    {
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; }

        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }


    }
}