using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubLecturaAPI.Models
{
    public class Reunion
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(150)]
        public string Lugar { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Tema { get; set; } = string.Empty;

        // Relación con Libro (la reunión trata sobre un libro)
        public int LibroId { get; set; }

        [ForeignKey(nameof(LibroId))]
        public Libro? Libro { get; set; }
    }
}
