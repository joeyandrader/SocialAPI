using System.ComponentModel.DataAnnotations;

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
        public Post? Post { get; set; }
        public Usuario? Usuario { get; set; }
        #endregion
    }
}
