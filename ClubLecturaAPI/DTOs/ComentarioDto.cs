namespace ClubLecturaAPI.DTOs
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
        public int Calificacion { get; set; }
        public DateTime FechaComentario { get; set; }
        public int MiembroId { get; set; }
        public string MiembroNombre { get; set; } = string.Empty;
        public int LibroId { get; set; }
        public string LibroTitulo { get; set; } = string.Empty;
    }
}
