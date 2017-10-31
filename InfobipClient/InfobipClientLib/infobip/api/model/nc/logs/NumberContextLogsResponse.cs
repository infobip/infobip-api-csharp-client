using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc.logs
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextLogsResponse
    {
        [JsonProperty("results")]
        public List<NumberContextLog> Results { get; set; } = new List<NumberContextLog>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as NumberContextLogsResponse;
            return thisClass != null &&
                EqualityComparer<List<NumberContextLog>>.Default.Equals(Results, thisClass.Results);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<NumberContextLog>>.Default.GetHashCode(Results);
            return hashCode;
        }
    }
}