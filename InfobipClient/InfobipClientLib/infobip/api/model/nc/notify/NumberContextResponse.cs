using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc.notify
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("results")]
        public List<NumberContextResponseDetails> Results { get; set; } = new List<NumberContextResponseDetails>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as NumberContextResponse;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<List<NumberContextResponseDetails>>.Default.Equals(Results, thisClass.Results);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<NumberContextResponseDetails>>.Default.GetHashCode(Results);
            return hashCode;
        }
    }
}