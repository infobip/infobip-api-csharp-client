using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Status
    {
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("groupId")]
        public int? GroupId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Status;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(GroupName, thisClass.GroupName) &&
                EqualityComparer<int?>.Default.Equals(GroupId, thisClass.GroupId) &&
                EqualityComparer<string>.Default.Equals(Name, thisClass.Name) &&
                EqualityComparer<string>.Default.Equals(Description, thisClass.Description) &&
                EqualityComparer<string>.Default.Equals(Action, thisClass.Action) &&
                EqualityComparer<int?>.Default.Equals(Id, thisClass.Id);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(GroupId);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Action);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}