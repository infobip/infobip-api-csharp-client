using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
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

        public override bool Equals(object obj)
        {
            var thisClass = obj as DeliveryTimeWindow;
            return thisClass != null &&
                EqualityComparer<List<DeliveryDay>>.Default.Equals(Days, thisClass.Days) &&
                EqualityComparer<DeliveryTime>.Default.Equals(From, thisClass.From) &&
                EqualityComparer<DeliveryTime>.Default.Equals(To, thisClass.To);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<DeliveryDay>>.Default.GetHashCode(Days);
            hashCode = hashCode * -1521134295 +  EqualityComparer<DeliveryTime>.Default.GetHashCode(From);
            hashCode = hashCode * -1521134295 +  EqualityComparer<DeliveryTime>.Default.GetHashCode(To);
            return hashCode;
        }
    }
}