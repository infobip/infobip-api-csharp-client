using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.account
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class AccountBalance
    {
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as AccountBalance;
            return thisClass != null &&
                EqualityComparer<decimal?>.Default.Equals(Balance, thisClass.Balance) &&
                EqualityComparer<string>.Default.Equals(Currency, thisClass.Currency);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<decimal?>.Default.GetHashCode(Balance);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Currency);
            return hashCode;
        }
    }
}