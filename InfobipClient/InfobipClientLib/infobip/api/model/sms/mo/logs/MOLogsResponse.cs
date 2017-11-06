using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mo.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOLogsResponse
    {
        [JsonProperty("results")]
        public List<MOLog> Results { get; set; } = new List<MOLog>();


    }
}