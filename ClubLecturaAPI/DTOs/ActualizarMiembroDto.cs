using System.ComponentModel.DataAnnotations;

namespace ClubLecturaAPI.DTOs
{
    public class ActualizarMiembroDto
    {
        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; }
    }
}
