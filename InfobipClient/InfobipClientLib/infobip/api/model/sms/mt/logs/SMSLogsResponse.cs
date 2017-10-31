using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class SMSLogsResponse
    {
        [JsonProperty("results")]
        public List<SMSLog> Results { get; set; } = new List<SMSLog>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as SMSLogsResponse;
            return thisClass != null &&
                EqualityComparer<List<SMSLog>>.Default.Equals(Results, thisClass.Results);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<SMSLog>>.Default.GetHashCode(Results);
            return hashCode;
        }
    }
}