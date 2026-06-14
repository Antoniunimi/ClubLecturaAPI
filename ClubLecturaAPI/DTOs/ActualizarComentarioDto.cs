using System.ComponentModel.DataAnnotations;

namespace ClubLecturaAPI.DTOs
{
    public class ActualizarComentarioDto
    {
        [Required]
        [MaxLength(500)]
        public string Texto { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Calificacion { get; set; }

        public DateTime FechaComentario { get; set; }

        [Required]
        public int MiembroId { get; set; }

        [Required]
        public int LibroId { get; set; }
    }
}
