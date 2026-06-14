using System.ComponentModel.DataAnnotations;

namespace ClubLecturaAPI.DTOs
{
    public class CrearReunionDto
    {
        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(150)]
        public string Lugar { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Tema { get; set; } = string.Empty;

        [Required]
        public int LibroId { get; set; }
    }
}
