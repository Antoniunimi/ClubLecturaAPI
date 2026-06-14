using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubLecturaAPI.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Texto { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Calificacion { get; set; }

        public DateTime FechaComentario { get; set; }

        // Relación con Miembro (quién hizo el comentario)
        public int MiembroId { get; set; }

        [ForeignKey(nameof(MiembroId))]
        public Miembro? Miembro { get; set; }

        // Relación con Libro (sobre qué libro es el comentario)
        public int LibroId { get; set; }

        [ForeignKey(nameof(LibroId))]
        public Libro? Libro { get; set; }
    }
}
