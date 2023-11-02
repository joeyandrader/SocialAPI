using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Base.DB
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        //DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Postagem { get; set; }
        public DbSet<Photos> Fotos { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }

    }
}