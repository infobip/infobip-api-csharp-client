using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextLogsResponse
    {
        [JsonProperty("results")]
        public List<NumberContextLog> Results { get; set; } = new List<NumberContextLog>();


    }
}