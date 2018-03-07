using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Scenarios
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetScenariosExecuteContext
    {
        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }


    }
}