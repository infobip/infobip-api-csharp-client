using System.Collections.Generic;
using Infobip.Api.Model.Nc.Notify;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc.Notify
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextResponse
    {
        [JsonProperty("results")]
        public IList<NumberContextResponseDetails> Results { get; set; }

        [JsonProperty("bulkId")]
        public string BulkId { get; set; }


    }
}