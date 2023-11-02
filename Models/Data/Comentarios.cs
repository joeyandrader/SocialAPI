using System.ComponentModel.DataAnnotations;

namespace RedeSocialAPI.Models.Data
{
    public class Comentarios
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UsuarioId { get; set; }
        public string? Texto { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        #region Relacionamento
        public Post? Post { get; set; }
        public Usuario? Usuario { get; set; }
        #endregion
    }
}
