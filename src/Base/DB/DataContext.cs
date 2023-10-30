using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.src.Base.DB
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(AppSettings.SQLConnectionString));
        }

        //DbSet
        public DbSet<Usuario> Usuarios;
    }
}