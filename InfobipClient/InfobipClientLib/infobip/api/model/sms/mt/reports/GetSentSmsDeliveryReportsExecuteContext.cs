using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetSentSmsDeliveryReportsExecuteContext
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }


    }
}