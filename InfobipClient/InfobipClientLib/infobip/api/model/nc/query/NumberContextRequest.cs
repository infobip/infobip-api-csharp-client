using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc.Query
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextRequest
    {
        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();


    }
}