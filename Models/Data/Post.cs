using System.ComponentModel.DataAnnotations;

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
        public Usuario? Usuario { get; set; }
        public ICollection<Photos>? Fotos { get; set; } = new List<Photos>();
        #endregion
    }
}
