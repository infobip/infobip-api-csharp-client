using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSMultiBinaryRequest
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; } = new List<Message>();


    }
}