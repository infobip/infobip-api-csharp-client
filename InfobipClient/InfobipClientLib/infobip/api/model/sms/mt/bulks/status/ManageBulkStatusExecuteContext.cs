using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.bulks.status
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class ManageBulkStatusExecuteContext
    {
        [JsonProperty("bulkId")]
        public string BulkId { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as ManageBulkStatusExecuteContext;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(BulkId, thisClass.BulkId);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(BulkId);
            return hashCode;
        }
    }
}