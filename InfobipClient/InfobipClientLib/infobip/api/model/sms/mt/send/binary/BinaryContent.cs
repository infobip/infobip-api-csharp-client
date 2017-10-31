using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BinaryContent
    {
        [JsonProperty("dataCoding")]
        public int? DataCoding { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("esmClass")]
        public int? EsmClass { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as BinaryContent;
            return thisClass != null &&
                EqualityComparer<int?>.Default.Equals(DataCoding, thisClass.DataCoding) &&
                EqualityComparer<string>.Default.Equals(Hex, thisClass.Hex) &&
                EqualityComparer<int?>.Default.Equals(EsmClass, thisClass.EsmClass);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(DataCoding);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Hex);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(EsmClass);
            return hashCode;
        }
    }
}