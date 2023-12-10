using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNotes.Models;
namespace AspNotes
{
    public class AspNotesContext : DbContext
    {
        public DbSet<Nota> Notas {get; set;}
        public DbSet<Pasta> Pastas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}

                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=1234;Database=teste");
    }
}