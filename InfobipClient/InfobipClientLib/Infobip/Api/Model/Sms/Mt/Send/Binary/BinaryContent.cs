using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Sms.Mt.Send.Binary
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class BinaryContent
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("dataCoding")]
        public int? DataCoding { get; set; }

        [JsonProperty("esmClass")]
        public int? EsmClass { get; set; }


    }
}