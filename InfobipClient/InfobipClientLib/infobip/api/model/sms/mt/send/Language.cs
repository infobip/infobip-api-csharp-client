using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Language
    {
        [JsonProperty("lockingShift")]
        public bool? LockingShift { get; set; }

        [JsonProperty("singleShift")]
        public bool? SingleShift { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Language;
            return thisClass != null &&
                EqualityComparer<bool?>.Default.Equals(LockingShift, thisClass.LockingShift) &&
                EqualityComparer<bool?>.Default.Equals(SingleShift, thisClass.SingleShift) &&
                EqualityComparer<string>.Default.Equals(LanguageCode, thisClass.LanguageCode);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(LockingShift);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(SingleShift);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(LanguageCode);
            return hashCode;
        }
    }
}