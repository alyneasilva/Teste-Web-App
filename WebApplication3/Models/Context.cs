using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Context: DbContext
    {
        public DbSet<Equipamentos> Equipamentos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-97PG5VM\SQLEXPRESS;Database=TesteApp; User Id=sa; Password=Simba@28; Integrated Security=True");
        }

    }
}
