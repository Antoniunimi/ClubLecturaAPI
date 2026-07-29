using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public string Texto { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public DateTime FechaComentario { get; set; }


        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }


        public int LibroId { get; set; }
        public Libro? Libro { get; set; }
    }
}
