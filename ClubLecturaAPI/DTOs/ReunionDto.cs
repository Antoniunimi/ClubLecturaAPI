namespace ClubLecturaAPI.DTOs
{
    public class ReunionDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;
        public int LibroId { get; set; }
        public string LibroTitulo { get; set; } = string.Empty;
    }
}
