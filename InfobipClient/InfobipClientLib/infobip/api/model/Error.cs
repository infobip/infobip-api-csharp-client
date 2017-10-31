using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model
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

        public override bool Equals(object obj)
        {
            var thisClass = obj as Error;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(GroupName, thisClass.GroupName) &&
                EqualityComparer<bool?>.Default.Equals(Permanent, thisClass.Permanent) &&
                EqualityComparer<int?>.Default.Equals(GroupId, thisClass.GroupId) &&
                EqualityComparer<string>.Default.Equals(Name, thisClass.Name) &&
                EqualityComparer<string>.Default.Equals(Description, thisClass.Description) &&
                EqualityComparer<int?>.Default.Equals(Id, thisClass.Id);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 +  EqualityComparer<bool?>.Default.GetHashCode(Permanent);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(GroupId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}