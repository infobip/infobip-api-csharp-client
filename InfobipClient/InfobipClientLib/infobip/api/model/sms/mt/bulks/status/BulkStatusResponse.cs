using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.bulks.status
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BulkStatusResponse
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        [JsonProperty("status")]
        public BulkStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as BulkStatusResponse;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId) &&
                EqualityComparer<BulkStatus>.Default.Equals(Status, thisClass.Status);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<BulkStatus>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}