using System.Collections.Generic;
using Infobip.Api.Model.Sms.Mt.Send;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class DeliveryTimeWindow
    {
        [JsonProperty("from")]
        public DeliveryTime From { get; set; }

        [JsonProperty("to")]
        public DeliveryTime To { get; set; }

        [JsonProperty("days")]
        public IList<DeliveryDay> Days { get; set; }


    }
}