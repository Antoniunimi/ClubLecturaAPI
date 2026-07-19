namespace ClubLectura.Infrastructure.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public DateTime FechaComentario { get; set; }
        public int MiembroId { get; set; }
        public int LibroId { get; set; }
    }
}
