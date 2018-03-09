using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model.Nc.Logs;

namespace Infobip.Api.Model.Nc.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextLogsResponse
    {
        [JsonProperty("results")]
        public IList<NumberContextLog> Results { get; set; }


    }
}