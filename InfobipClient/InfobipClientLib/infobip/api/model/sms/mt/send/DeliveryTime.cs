using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
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

        public override bool Equals(object obj)
        {
            var thisClass = obj as DeliveryTime;
            return thisClass != null &&
                EqualityComparer<int?>.Default.Equals(Hour, thisClass.Hour) &&
                EqualityComparer<int?>.Default.Equals(Minute, thisClass.Minute);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Hour);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Minute);
            return hashCode;
        }
    }
}