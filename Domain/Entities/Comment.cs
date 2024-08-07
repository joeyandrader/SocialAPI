using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? PersonId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        #region Relations
        [JsonIgnore, XmlIgnore]
        public Post? Posts { get; set; }
        [JsonIgnore, XmlIgnore]
        public Person? Person { get; set; }
        #endregion
    }
}
