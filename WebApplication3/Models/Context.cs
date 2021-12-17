using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Context: DbContext
    {
        public DbSet<Equipamentos> Equipamentos { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-97PG5VM\SQLEXPRESS;Database=TesteApp; User Id=sa; Password=Simba@28; Integrated Security=True");
        }
        //public DbSet<WebApplication3.Models.Usuarios> Usuarios { get; set; }

    }
}
