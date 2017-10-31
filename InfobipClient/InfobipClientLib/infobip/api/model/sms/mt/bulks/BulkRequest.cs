using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.bulks
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BulkRequest
    {
        [JsonProperty("sendAt")]
        public DateTimeOffset SendAt { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as BulkRequest;
            return thisClass != null &&
                EqualityComparer<DateTimeOffset>.Default.Equals(SendAt, thisClass.SendAt);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<DateTimeOffset>.Default.GetHashCode(SendAt);
            return hashCode;
        }
    }
}