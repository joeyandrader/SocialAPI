

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Entities
{
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        [JsonIgnore, XmlIgnore]
        public Post Post { get; set; }
        [JsonIgnore, XmlIgnore]
        public Tag Tag { get; set; }
    }
}
