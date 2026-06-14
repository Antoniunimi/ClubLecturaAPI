using System.ComponentModel.DataAnnotations;

namespace ClubLecturaAPI.DTOs
{
    public class CrearLibroDto
    {
        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Autor { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;

        public int AnioPublicacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genero { get; set; } = string.Empty;
    }
}
