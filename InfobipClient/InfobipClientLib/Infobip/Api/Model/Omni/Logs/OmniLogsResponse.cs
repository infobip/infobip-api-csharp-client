using Infobip.Api.Model.Omni.Logs;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OmniLogsResponse
    {
        [JsonProperty("results")]
        public IList<OmniLog> Results { get; set; }


    }
}