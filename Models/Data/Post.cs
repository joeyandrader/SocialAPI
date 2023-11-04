using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.DB;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RedeSocialAPI.Models.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int UsuarioId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        #region ForeignKey
        public Usuario? Usuario { get; set; }

        public ICollection<Photos>? Fotos { get; set; } = new List<Photos>();

        public ICollection<Comentarios>? Comentario { get; set; } = new List<Comentarios>();

        public ICollection<Like>? Like { get; set; } = new List<Like>();


        #endregion
    }
}
