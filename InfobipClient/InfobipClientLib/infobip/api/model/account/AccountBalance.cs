using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Account
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


    }
}