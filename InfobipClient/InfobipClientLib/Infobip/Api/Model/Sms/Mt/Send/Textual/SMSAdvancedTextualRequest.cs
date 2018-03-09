using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Send;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Textual
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSAdvancedTextualRequest
    {
        [JsonProperty("tracking")]
        public Tracking Tracking { get; set; }

        [JsonProperty("messages")]
        public IList<Message> Messages { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }


    }
}