using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.Models.Data
{
    [Index(nameof(Email), IsUnique = true)] //Faz com que o email seja unico
    [Index(nameof(Username), IsUnique = true)] //Faz com que o username seja unico
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Biography { get; set; }

        [Required]
        public string? Password { get; set; }

        [DefaultValue(0)]
        public AccountType AccountType { get; set; } = AccountType.Comum;

        [DefaultValue(false)]
        public bool Active { get; set; } = false;

        [DefaultValue("profileDefault.png")]
        public string? ImageUrl { get; set; } = "profileDefault.png";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;



        #region Rellations
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Post>? Postagens { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Like>? Like { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Valida senha ao efetuar o login
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidaSenha(string password)
        {
            return Password == password.GerarHash();
        }


        /// <summary>
        /// Seta a hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GeraPassHash(string password)
        {
            return Password = password.GerarHash();
        }
        #endregion
    }
}