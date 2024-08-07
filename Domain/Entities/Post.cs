
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int? PersonId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #region Relations
        [JsonIgnore, XmlIgnore]
        public Person? Person { get; set; }
        #endregion
    }
}
