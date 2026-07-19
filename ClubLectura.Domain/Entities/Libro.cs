using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Libro : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
