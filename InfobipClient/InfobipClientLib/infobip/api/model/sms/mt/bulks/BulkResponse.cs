using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Bulks
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BulkResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }


    }
}