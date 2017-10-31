using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Network
    {
        [JsonProperty("countryPrefix")]
        public string CountryPrefix { get; set; }

        [JsonProperty("networkName")]
        public string NetworkName { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("networkPrefix")]
        public string NetworkPrefix { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Network;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(CountryPrefix, thisClass.CountryPrefix) &&
                EqualityComparer<string>.Default.Equals(NetworkName, thisClass.NetworkName) &&
                EqualityComparer<string>.Default.Equals(CountryName, thisClass.CountryName) &&
                EqualityComparer<string>.Default.Equals(NetworkPrefix, thisClass.NetworkPrefix);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CountryPrefix);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NetworkName);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(CountryName);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NetworkPrefix);
            return hashCode;
        }
    }
}