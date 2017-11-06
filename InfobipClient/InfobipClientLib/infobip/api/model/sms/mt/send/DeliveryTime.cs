using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class DeliveryTime
    {
        [JsonProperty("hour")]
        public int? Hour { get; set; }

        [JsonProperty("minute")]
        public int? Minute { get; set; }


    }
}