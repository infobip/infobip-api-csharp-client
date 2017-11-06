using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class DeliveryTimeWindow
    {
        [JsonProperty("days")]
        public List<DeliveryDay> Days { get; set; } = new List<DeliveryDay>();

        [JsonProperty("from")]
        public DeliveryTime From { get; set; }

        [JsonProperty("to")]
        public DeliveryTime To { get; set; }


    }
}