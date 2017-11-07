using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSLogsResponse
    {
        [JsonProperty("results")]
        public List<SMSLog> Results { get; set; }


    }
}