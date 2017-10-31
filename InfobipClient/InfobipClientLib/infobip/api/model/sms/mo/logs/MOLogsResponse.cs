using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mo.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class MOLogsResponse
    {
        [JsonProperty("results")]
        public List<MOLog> Results { get; set; } = new List<MOLog>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as MOLogsResponse;
            return thisClass != null &&
                EqualityComparer<List<MOLog>>.Default.Equals(Results, thisClass.Results);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<MOLog>>.Default.GetHashCode(Results);
            return hashCode;
        }
    }
}