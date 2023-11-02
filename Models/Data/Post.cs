using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RedeSocialAPI.Models.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Text { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        #region ForeignKey
        [XmlIgnore]
        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        public ICollection<Photos>? Fotos { get; set; } = new List<Photos>();

        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Comentarios>? Comentario { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Post>? Like { get; set; }
        #endregion
    }
}
