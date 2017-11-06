using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Bulks.Status
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BulkStatusResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("status")]
        public BulkStatus Status { get; set; }


    }
}