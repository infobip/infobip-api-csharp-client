using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NotificationOptions
    {
        [JsonProperty("vibrationEnabled")]
        public bool? VibrationEnabled { get; set; }

        [JsonProperty("soundEnabled")]
        public bool? SoundEnabled { get; set; }

        [JsonProperty("soundName")]
        public string SoundName { get; set; }

        [JsonProperty("badge")]
        public int? Badge { get; set; }

        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }


    }
}