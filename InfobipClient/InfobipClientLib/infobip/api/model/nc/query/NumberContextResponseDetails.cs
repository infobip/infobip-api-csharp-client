using InfobipClient.infobip.api.model.nc;
using System.Collections.Generic;
using InfobipClient.infobip.api.model;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc.query
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextResponseDetails
    {
        [JsonProperty("ported")]
        public bool? Ported { get; set; }

        [JsonProperty("roaming")]
        public bool? Roaming { get; set; }

        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        [JsonProperty("roamingNetwork")]
        public Network RoamingNetwork { get; set; }

        [JsonProperty("portedNetwork")]
        public Network PortedNetwork { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("imsi")]
        public string Imsi { get; set; }

        [JsonProperty("servingMSC")]
        public string ServingMSC { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("originalNetwork")]
        public Network OriginalNetwork { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as NumberContextResponseDetails;
            return thisClass != null &&
                EqualityComparer<bool?>.Default.Equals(Ported, thisClass.Ported) &&
                EqualityComparer<bool?>.Default.Equals(Roaming, thisClass.Roaming) &&
                EqualityComparer<string>.Default.Equals(MccMnc, thisClass.MccMnc) &&
                EqualityComparer<Network>.Default.Equals(RoamingNetwork, thisClass.RoamingNetwork) &&
                EqualityComparer<Network>.Default.Equals(PortedNetwork, thisClass.PortedNetwork) &&
                EqualityComparer<string>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(Imsi, thisClass.Imsi) &&
                EqualityComparer<string>.Default.Equals(ServingMSC, thisClass.ServingMSC) &&
                EqualityComparer<Error>.Default.Equals(Error, thisClass.Error) &&
                EqualityComparer<Network>.Default.Equals(OriginalNetwork, thisClass.OriginalNetwork) &&
                EqualityComparer<Status>.Default.Equals(Status, thisClass.Status);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(Ported);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(Roaming);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(MccMnc);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Network>.Default.GetHashCode(RoamingNetwork);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Network>.Default.GetHashCode(PortedNetwork);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Imsi);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(ServingMSC);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Error>.Default.GetHashCode(Error);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Network>.Default.GetHashCode(OriginalNetwork);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Status>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}