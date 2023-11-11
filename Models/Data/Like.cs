using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RedeSocialAPI.Models.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CreatedAt { get; set; }

        #region Relacionamento
        [JsonIgnore]
        [XmlIgnore]
        public Post? Post { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Usuario? Usuario { get; set; }
        #endregion
    }
}
