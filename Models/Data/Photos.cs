using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RedeSocialAPI.Models.Data
{
    public class Photos
    {
        [Key]
        public int Id { get; set; }
        public string? UrlPhoto { get; set; }

        public int PostId { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Post? Post { get; set; }
    }
}
