using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Error
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("permanent")]
        public bool? Permanent { get; set; }

        [JsonProperty("groupId")]
        public int? GroupId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }


    }
}