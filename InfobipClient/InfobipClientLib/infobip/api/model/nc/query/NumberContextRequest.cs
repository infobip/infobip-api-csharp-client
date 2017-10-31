using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc.query
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextRequest
    {
        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as NumberContextRequest;
            return thisClass != null &&
                EqualityComparer<List<string>>.Default.Equals(To, thisClass.To);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<string>>.Default.GetHashCode(To);
            return hashCode;
        }
    }
}