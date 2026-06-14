using ClubLecturaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubLecturaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Reunion> Reuniones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
