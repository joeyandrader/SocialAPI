using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain.Entities
{
    internal class Followers
    {
        public int FollowerId { get; set; }
        public int FollowedId { get; set; }

        #region Relations
        [JsonIgnore, XmlIgnore]
        public Person? Follower { get; set; }
        [JsonIgnore, XmlIgnore]
        public Person? Followed { get; set; }
        #endregion
    }
}
