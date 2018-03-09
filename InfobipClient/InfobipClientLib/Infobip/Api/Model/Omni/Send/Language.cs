using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Language
    {
        [JsonProperty("singleShift")]
        public bool? SingleShift { get; set; }

        [JsonProperty("lockingShift")]
        public bool? LockingShift { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }


    }
}