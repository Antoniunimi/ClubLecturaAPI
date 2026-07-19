using ClubLectura.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubLectura.Infrastructure.Context
{
    public class ClubLecturaContext : DbContext
    {
        public ClubLecturaContext(DbContextOptions<ClubLecturaContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Reunion> Reuniones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
