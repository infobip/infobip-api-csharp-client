using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni.Send;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OmniResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("messages")]
        public IList<OmniResponseDetails> Messages { get; set; }


    }
}