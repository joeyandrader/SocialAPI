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


    }
}