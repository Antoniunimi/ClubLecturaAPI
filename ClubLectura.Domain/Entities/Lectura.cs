using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Lectura : BaseEntity
    {
        public DateTime FechaLectura { get; set; }
        public int Valoracion { get; set; }
        public int CantidadLecturas { get; set; }

        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }

        public int LibroId { get; set; }
        public Libro? Libro { get; set; }
    }
}
