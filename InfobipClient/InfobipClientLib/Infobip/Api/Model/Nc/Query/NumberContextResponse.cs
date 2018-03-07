using System.Collections.Generic;
using Infobip.Api.Model.Nc.Query;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc.Query
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