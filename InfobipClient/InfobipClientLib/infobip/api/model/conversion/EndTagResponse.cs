using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.conversion
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class EndTagResponse
    {
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as EndTagResponse;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(ProcessKey, thisClass.ProcessKey);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(ProcessKey);
            return hashCode;
        }
    }
}