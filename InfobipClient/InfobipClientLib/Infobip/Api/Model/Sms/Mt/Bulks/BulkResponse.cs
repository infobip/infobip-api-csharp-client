using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Config;
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
        public FormattedDate SendAt { get; set; }


    }
}