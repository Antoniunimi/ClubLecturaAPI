using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Reunion : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;


        public int LibroId { get; set; }
        public Libro? Libro { get; set; }
    }
}
