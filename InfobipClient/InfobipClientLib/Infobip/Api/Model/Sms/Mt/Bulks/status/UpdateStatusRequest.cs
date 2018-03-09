using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Bulks.Status;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Bulks.Status
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class UpdateStatusRequest
    {
        [JsonProperty("status")]
        public BulkStatus Status { get; set; }


    }
}